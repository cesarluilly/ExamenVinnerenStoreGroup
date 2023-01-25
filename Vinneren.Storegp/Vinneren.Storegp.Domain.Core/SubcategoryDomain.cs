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
    public class SubcategoryDomain : ISubcategoryDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public SubcategoryDomain(

            IUnitOfWork unitOfWork_I
            )
        {
            _unitOfWork= unitOfWork_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        public int subAdd(SubcategoryEntity subcategory)
        {
            _unitOfWork.SubcategoryRepo.AddOne(subcategory);
            _unitOfWork.Save();
            return subcategory.Pk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public SubcategoryEntity subGet(int intPk)
        {
            return _unitOfWork.SubcategoryRepo.GetOneByPk(intPk).FirstOrDefault();
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<SubcategoryEntity> subGetAll()
        {
            return _unitOfWork.SubcategoryRepo.GetAll().ToList();
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subRemove(SubcategoryBso subcategoryToDelete)
        {
            subcategoryToDelete.subDeleteAtDB();
            return null;
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subUpdate(String strName, int intId, SubcategoryBso subcategoryToUpdate)
        {
            subcategoryToUpdate.Name = strName;
            subcategoryToUpdate.Id = intId;
            subcategoryToUpdate.subUpdateAtDB();

            return null;
        }
    }
}
