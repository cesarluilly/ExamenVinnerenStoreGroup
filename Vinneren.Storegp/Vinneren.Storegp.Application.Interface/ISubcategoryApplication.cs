using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Transversal.Common;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 27, 2023. 
namespace Vinneren.Storegp.Application.Interface
{
    //==================================================================================================================
    public interface ISubcategoryApplication
    {
        public ResResponse<int> subAdd(SubcategoryDto subcategory);
        public ResResponse<Empty> subUpdate(SubcategoryDto subcategory);
        public ResResponse<SubcategoryDto> subGet(int intPk);
        public ResResponse<List<SubcategoryDto>> subGetAll();
        public ResResponse<Empty> subDelete(int intPk);
    }

    //==================================================================================================================
}
