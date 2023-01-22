using Microsoft.EntityFrameworkCore;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Infraescructure.Data
{
    //==================================================================================================================
    public class VinnContext : DbContext
    {
        public VinnContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder
            )
        {
            
        }
    }
}