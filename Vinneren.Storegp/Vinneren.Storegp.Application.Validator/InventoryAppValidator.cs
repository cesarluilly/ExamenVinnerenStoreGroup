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
    public static class InventoryAppValidator
    {
        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForAdd(
            
            InventoryDto inventoryDto, 
            Status status_I
            )
        {
            if (
                inventoryDto != null
                )
            {
                if (
                    inventoryDto.Note != null &&
                    inventoryDto.Note.Length < 100
                    )
                {
                    //                                      //Do not something.
                }
                else
                {
                    status_I.subSetDevError("Note is very big");
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
            out InventoryBso inventoryBso_O
            )
        {
            inventoryBso_O = InventoryBso.inventoryFromDB(intPk_I, unitOfWork_I, true);
            if (
                inventoryBso_O != null
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

            InventoryDto inventoryDto,
            Status status_I,
            IUnitOfWork unitOfWork_I,
            out InventoryBso inventoryBso_O
            )
        {
            inventoryBso_O = InventoryBso.inventoryFromDB(inventoryDto.Pk, unitOfWork_I, true);
            if (
                inventoryBso_O != null
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
