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
    public interface ISubcategory
    {
        public int Pk { get; set; }
        public String? Name { get; set; }
        public int Id { get; set; }
        public int PkCategory { get; set; }
    }
}
