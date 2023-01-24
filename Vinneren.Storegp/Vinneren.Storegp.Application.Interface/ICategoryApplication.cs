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
    public interface ICategoryApplication
    {
        public ResResponse<int> subAdd(CategoryDto category);
        public ResResponse<Empty> subUpdate(CategoryDto category);
        public ResResponse<CategoryDto> subGet(int intPk);
        public ResResponse<List<CategoryDto>> subGetAll();
        public ResResponse<Empty> subRemove(int intPk);
    }

    //==================================================================================================================
}
