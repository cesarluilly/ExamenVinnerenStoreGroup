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
    public class ProductDto : IProduct
    {
        public int Pk { get; set; }
        public String? Name { get; set; }
        public String? NumMaterial { get; set; }
        public int PkSubCategory { get; set; }
    }
}
