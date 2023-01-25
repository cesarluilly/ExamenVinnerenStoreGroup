using Microsoft.EntityFrameworkCore;
using Vinneren.Storegp.Application.Interface;
using Vinneren.Storegp.Application.Main;
using Vinneren.Storegp.Domain.Core;
using Vinneren.Storegp.Domain.Interface;
using Vinneren.Storegp.Infraescructure.Data;
using Vinneren.Storegp.Infraescructure.Interface;
using Vinneren.Storegp.Infraescructure.Repository;
using Vinneren.Storegp.Transversal.Mapper;

namespace WebApplication1Vinneren.Storegp.Service.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutoMapperConfig.Configure();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //                                              //Movemos el lugar donde se agregaran
            //                                              //  los archivos de migracion.
            services.AddDbContext<VinnContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"),
                     b => b.MigrationsAssembly("WebApplication1Vinneren.Storegp.Service.WebApi"));
            });

            services.AddControllersWithViews();

            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<ICategoryDomain, CategoryDomain>();

            services.AddScoped<ISubcategoryApplication, SubcategoryApplication>();
            services.AddScoped<ISubcategoryDomain, SubcategoryDomain>();

            services.AddScoped<IInventoryApplication, InventoryApplication>();
            services.AddScoped<IInventoryDomain, InventoryDomain>();

            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IProductDomain, ProductDomain>();

            services.AddScoped<IInventoryProductApplication, InventoryProductApplication>();
            services.AddScoped<IInventoryProductDomain, InventoryProductDomain>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            //                                              //Crear base de datos cuando se corre la aplicacion.
            //                                              //Migrate any database changes on
            //                                              //  startup (includes initial db
            //                                              //  creation)
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<VinnContext>();
                dataContext.Database.Migrate();
            }
        }
    }
}
