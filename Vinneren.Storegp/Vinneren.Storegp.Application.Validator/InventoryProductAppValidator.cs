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
    public static class InventoryProductAppValidator
    {
        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForAdd(
            
            InventoryProductDto inventoryProductDto, 
            IUnitOfWork unitOfWork_I,
            Status status_I
            )
        {
            if (
                inventoryProductDto != null
                )
            {
                if (
                    inventoryProductDto.Units >= 0
                    )
                {
                    if (
                        inventoryProductDto.Note.Length < 100
                        )
                    {
                        //                                  //Do not somethign.
                    }
                    else
                    {
                        status_I.subSetDevError("Note is very big");
                    }
                }
                else
                {
                    status_I.subSetDevError("Units is negative");
                }
            }
            else
            {
                status_I.subSetDevError("Dto is null");
            }

            if (
                status_I.boolStatusOk
                )
            {
                InventoryBso inventoryBso = InventoryBso.inventoryFromDB(inventoryProductDto.PkInventory,
                            unitOfWork_I, true);
                if (
                    inventoryBso != null
                    )
                {
                    ProductBso productBso = ProductBso.productFromDB(inventoryProductDto.PkProduct, unitOfWork_I, 
                        true);

                    if (
                        productBso != null
                        )
                    {
                        //                                  //Do not something.
                    }
                    else
                    {
                        status_I.subSetDevError("Pk Product is not valid.");
                    }
                }
                else
                {
                    status_I.subSetDevError("Pk inventory is not valid.");
                }
            }

            return status_I.boolStatusOk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public static bool isValidForDelete(

            int intPk_I,
            Status status_I, 
            IUnitOfWork unitOfWork_I, 
            out InventoryProductBso inventoryProductBso_O
            )
        {
            inventoryProductBso_O = InventoryProductBso.inventoryProductFromDB(intPk_I, null, null, 
                unitOfWork_I, true);
            if (
                inventoryProductBso_O != null
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

            InventoryProductDto productDto,
            Status status_I,
            IUnitOfWork unitOfWork_I,
            out InventoryProductBso inventoryProductBso_O
            )
        {
            inventoryProductBso_O = InventoryProductBso.inventoryProductFromDB(productDto.Pk, null, null, 
                unitOfWork_I, true);
            if (
                inventoryProductBso_O != null
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
