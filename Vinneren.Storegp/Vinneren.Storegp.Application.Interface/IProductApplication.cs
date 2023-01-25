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
    public interface IProductApplication
    {
        public ResResponse<int> subAdd(ProductDto productDto);
        public ResResponse<Empty> subUpdate(ProductDto productDto);
        public ResResponse<ProductDto> subGet(int intPk);
        public ResResponse<List<ProductDto>> subGetByCategoryOrSubCategory(
            String strCategory, String strSubCategory);
        public ResResponse<List<ProductDto>> subGetAll();
        public ResResponse<Empty> subDelete(int intPk);
    }

    //==================================================================================================================
}
