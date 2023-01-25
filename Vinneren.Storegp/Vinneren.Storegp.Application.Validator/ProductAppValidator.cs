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
            Status status_I,
            IUnitOfWork unitOfWork_I
            )
        {
            if (
                productDto != null
                )
            {
                if (
                    productDto.Name != null &&
                    productDto.Name.Length < 50
                    )
                {
                    if (
                        productDto.NumMaterial != null &&
                        productDto.NumMaterial.Length < 50
                        )   
                    {
                        if (
                            productDto.PkSubCategory > 0
                            )
                        {
                            SubcategoryBso subcategoryBso = SubcategoryBso.subcategoryFromDB(productDto.PkSubCategory, 
                                unitOfWork_I, false);

                            if (
                                subcategoryBso != null
                                )
                            {
                                //                          //Do not something.
                            }
                            else
                            {
                                status_I.subSetDevError("Not exist Subcategory with the Pk, Your need add a Subcategory.");
                            }
                        }
                        else
                        {
                            status_I.subSetDevError("PkSubcategory is negative or zero.");
                        }
                    }
                    else
                    {
                        status_I.subSetDevError("name material is very big");
                    }
                }
                else
                {
                    status_I.subSetDevError("name is very big");
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
                if (
                    productDto.Name != null &&
                    productDto.Name.Length < 50
                    )
                {
                    if (
                        productDto.NumMaterial != null &&
                        productDto.NumMaterial.Length < 50
                        )
                    {
                        //                                  //Do not something.
                    }
                    else
                    {
                        status_I.subSetDevError("name material is very big");
                    }
                }
                else
                {
                    status_I.subSetDevError("name is very big");
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
