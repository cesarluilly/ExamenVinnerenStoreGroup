using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Bso.BusinessClass;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Infraescructure.Interface;
using Vinneren.Storegp.Transversal.Common;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 23, 2023. 
namespace Vinneren.Storegp.Application.Validator
{
    //==================================================================================================================
    public static class CategoryAppValidator
    {
        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForAdd(
            
            CategoryDto Category, 
            Status status_I
            )
        {
            if (
                Category != null
                )
            {
                if (
                    Category.Name != null &&
                    Category.Name.Length < 50
                    )
                {
                    if (
                        Category.Id > 0
                        )
                    {
                        //                                  //Do not something.
                    }
                    else
                    {
                        status_I.subSetUserError("Id should be greater than zero.");
                    }
                }
                else
                {
                    status_I.subSetUserError("Name is very big");
                }
            }
            else
            {
                status_I.subSetDevError("Dto is null");
            }

            return status_I.boolStatusOk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForDelete(

            int intPk_I,
            Status status_I, 
            IUnitOfWork unitOfWork_I, 
            out CategoryBso category_O
            )
        {
            category_O = CategoryBso.categoryFromDB(intPk_I, unitOfWork_I, true);
            if (
                category_O != null
                )
            {
                //                                          //Do not something.
            }
            else
            {
                status_I.subSetDevError("Pk invalid.");
            }

            return status_I.boolStatusOk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForUpdate(

            CategoryDto categoryDto,
            Status status_I,
            IUnitOfWork unitOfWork_I,
            out CategoryBso category_O
            )
        {
            category_O = CategoryBso.categoryFromDB(categoryDto.Pk, unitOfWork_I, true);
            if (
                category_O != null
                )
            {
                if (
                    categoryDto.Id > 0 &&
                    categoryDto.Name != null &&
                    categoryDto.Name.Length < 50
                    ) 
                {
                    //                                          //Do not something.
                }
                else
                {
                    status_I.subSetDevError("Id or name invalid");
                }
            }
            else
            {
                status_I.subSetDevError("Pk invalid.");
            }

            return status_I.boolStatusOk;
        }
    }
}
