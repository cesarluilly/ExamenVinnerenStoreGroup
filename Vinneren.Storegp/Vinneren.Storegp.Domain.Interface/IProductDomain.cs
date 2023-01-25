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
    public interface IProductDomain
    {
        public int subAdd(ProductEntity productEntity);
        public ProductEntity subGet(int intPk);
        public List<ProductEntity> subGetAll();
        public List<ProductEntity> subGetByCategoryOrSubCategory(
            String strCategory, String strSubCategory);

        public List<ProductEntity> subGetByRangeInventory(
            int intInitial, int intEnd);
        public Empty subRemove(ProductBso productBsoToDelete);
        public Empty subUpdate(String strName, String strMaterial, ProductBso productbsoToUpdate);
    }

    //==================================================================================================================
}
