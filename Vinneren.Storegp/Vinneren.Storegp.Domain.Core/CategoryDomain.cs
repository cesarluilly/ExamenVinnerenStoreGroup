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
    public class CategoryDomain : ICategoryDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public CategoryDomain(

            IUnitOfWork unitOfWork_I
            )
        {
            _unitOfWork= unitOfWork_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        public int subAdd(CategoryEntity category)
        {
            _unitOfWork.CategoryRepo.AddOne(category);
            _unitOfWork.Save();
            return category.Pk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public CategoryEntity subGet(int intPk)
        {
            return _unitOfWork.CategoryRepo.GetOneByPk(intPk).FirstOrDefault();
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<CategoryEntity> subGetAll()
        {
            return _unitOfWork.CategoryRepo.GetAll().ToList();
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subRemove(CategoryBso categoryToDelete)
        {
            categoryToDelete.subDeleteAtDB();
            return null;
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subUpdate(String strName, int intId, CategoryBso categoryToUpdate)
        {
            categoryToUpdate.Name = strName;
            categoryToUpdate.Id = intId;
            categoryToUpdate.subUpdateAtDB();

            return null;
        }
    }
}
