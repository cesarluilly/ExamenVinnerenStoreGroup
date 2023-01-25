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
    public static class ProductAppValidator
    {
        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForAdd(
            
            ProductDto productDto, 
            Status status_I
            )
        {
            if (
                productDto != null
                )
            {
                
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
            out ProductBso productBso_O
            )
        {
            productBso_O = ProductBso.productFromDB(intPk_I, unitOfWork_I, true);
            if (
                productBso_O != null
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

            ProductDto productDto,
            Status status_I,
            IUnitOfWork unitOfWork_I,
            out ProductBso productBso_O
            )
        {
            productBso_O = ProductBso.productFromDB(productDto.Pk, unitOfWork_I, true);
            if (
                productBso_O != null
                )
            {
                
            }
            else
            {
                status_I.subSetDevError("Pk invalid.");
            }

            return status_I.boolStatusOk;
        }
    }
}
