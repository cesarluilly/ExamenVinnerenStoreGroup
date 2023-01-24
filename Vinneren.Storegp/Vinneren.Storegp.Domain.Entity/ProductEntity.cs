using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity.ByTable;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Domain.Entity
{
    //==================================================================================================================
    [Table("Product")]
    public class ProductEntity : IProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pk { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(50)")]
        public String? Name { get; set; }
        [Column("NumMaterial", TypeName = "nvarchar(50)")]
        public String? NumMaterial { get; set; }
    }
}
