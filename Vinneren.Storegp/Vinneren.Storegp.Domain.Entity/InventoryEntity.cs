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
    [Table("Inventory")]
    public class InventoryEntity : IInventory
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pk { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Column("Note", TypeName = "nvarchar(100)")]
        public string? Note { get; set; }
    }
}
