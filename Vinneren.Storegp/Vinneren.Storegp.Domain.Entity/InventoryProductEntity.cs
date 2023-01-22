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
        public int Pk {get; set;}
        public string? Name { get; set; }
        public int Id { get; set; }
        public int Units { get; set; }
        public string Note { get; set; }
        public int PkInventory { get; set; }
        public int PkProduct { get; set; }
    }
}
