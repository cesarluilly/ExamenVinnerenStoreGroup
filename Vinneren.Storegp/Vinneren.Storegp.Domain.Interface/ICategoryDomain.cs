using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Bso.BusinessClass;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Transversal.Common;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 27, 2023. 
namespace Vinneren.Storegp.Domain.Interface
{
    //==================================================================================================================
    public interface ICategoryDomain
    {
        public int subAdd(CategoryEntity category);
        public CategoryEntity subGet(int intPk);
        public List<CategoryEntity> subGetAll();
        public Empty subRemove(CategoryBso categoryToDelete);
        public Empty subUpdate(String strName, int intId, CategoryBso categoryToUpdate);
    }

    //==================================================================================================================
}
