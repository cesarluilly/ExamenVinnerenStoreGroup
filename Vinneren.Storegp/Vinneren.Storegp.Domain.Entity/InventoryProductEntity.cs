using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Interface.ByTable;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Domain.Entity
{
    //==================================================================================================================
    [Table("InventoryProduct")]
    public class InventoryProductEntity : IInventoryProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pk {get; set;}
        
        public int Units { get; set; }
        [Column("Note", TypeName = "nvarchar(100)")]
        public string Note { get; set; }

        [Required]
        public int PkInventory { get; set; }
        [ForeignKey("PkInventory")]
        public InventoryEntity? Inventory { get; set; }

        [Required]
        public int PkProduct { get; set; }
        [ForeignKey("PkProduct")]
        public ProductEntity ? Product { get; set; }
    }
}
