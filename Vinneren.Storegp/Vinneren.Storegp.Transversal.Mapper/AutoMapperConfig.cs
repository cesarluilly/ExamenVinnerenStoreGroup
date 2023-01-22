using AutoMapper;

namespace Vinneren.Storegp.Transversal.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingsProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}