using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Bso.BusinessClass;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Domain.Interface;
using Vinneren.Storegp.Infraescructure.Interface;
using Vinneren.Storegp.Transversal.Common;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 27, 2022. 
namespace Vinneren.Storegp.Domain.Core
{
    //==================================================================================================================
    public class ProductDomain : IProductDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public ProductDomain(

            IUnitOfWork unitOfWork_I
            )
        {
            _unitOfWork= unitOfWork_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        public int subAdd(ProductEntity productEntity)
        {
            _unitOfWork.ProductRepo.AddOne(productEntity);
            _unitOfWork.Save();
            return productEntity.Pk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ProductEntity subGet(int intPk)
        {
            return _unitOfWork.ProductRepo.GetOneByPk(intPk).FirstOrDefault();
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<ProductEntity> subGetAll()
        {
            return _unitOfWork.ProductRepo.GetAll().ToList();
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<ProductEntity> subGetByCategoryOrSubCategory(
            String strCategory, String strSubCategory)
        {
            return _unitOfWork.ProductRepo.GetByCategoryOrSubcategory(strCategory, 
                strSubCategory).ToList();
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<ProductEntity> GetByRangeInventory(
            int intInitial, int intEnd)
        {
            return _unitOfWork.ProductRepo.GetByRangeInventory(intInitial,
                intEnd).ToList();
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subRemove(ProductBso productBsoToDelete)
        {
            productBsoToDelete.subDeleteAtDB();
            return null;
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subUpdate(String strName, String strMaterial, ProductBso productbsoToUpdate)
        {
            productbsoToUpdate.Name = strName;
            productbsoToUpdate.NumMaterial = strMaterial;
            productbsoToUpdate.subUpdateAtDB();

            return null;
        }
    }
}
