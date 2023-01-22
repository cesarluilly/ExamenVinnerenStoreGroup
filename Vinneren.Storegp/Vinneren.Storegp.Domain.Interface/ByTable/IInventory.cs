using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Domain.Interface.ByTable
{
    //==================================================================================================================
    public interface IInventory
    {
        public int Pk { get; set; }
        public DateTime Date { get; set; }
        public String? Note { get; set; }
    }
}
