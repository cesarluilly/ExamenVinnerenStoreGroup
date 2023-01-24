using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Domain.Entity.ByTable
{
    //==================================================================================================================
    public interface IInventoryProduct
    {
        public int Pk { get; set; }
        public int Units { get; set; }
        public String? Note { get; set; }
        public int PkInventory { get; set; }
        public int PkProduct { get; set; }
    }
}
