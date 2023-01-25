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
    public static class SubcategoryAppValidator
    {
        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForAdd(
            
            SubcategoryDto subcategory, 
            Status status_I
            )
        {
            if (
                subcategory != null
                )
            {
                if (
                    subcategory.Name.Length < 50
                    )
                {
                    if (
                        subcategory.Id > 0
                        )
                    {

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
            out SubcategoryBso category_O
            )
        {
            category_O = SubcategoryBso.subcategoryFromDB(intPk_I, unitOfWork_I, true);
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

            SubcategoryDto subcategoryDto,
            Status status_I,
            IUnitOfWork unitOfWork_I,
            out SubcategoryBso category_O
            )
        {
            category_O = SubcategoryBso.subcategoryFromDB(subcategoryDto.Pk, unitOfWork_I, true);
            if (
                category_O != null
                )
            {
                if (
                    subcategoryDto.Id > 0 &&
                    subcategoryDto.Name.Length < 50
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
