using AutoMapper;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Application.Interface;
using Vinneren.Storegp.Application.Validator;
using Vinneren.Storegp.Domain.Bso.BusinessClass;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Domain.Interface;
using Vinneren.Storegp.Infraescructure.Interface;
using Vinneren.Storegp.Transversal.Common;
using Vinneren.Storegp.Transversal.Mapper;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 23, 2023. 
namespace Vinneren.Storegp.Application.Main
{
    public class SubcategoryApplication : ISubcategoryApplication
    {
        private readonly ISubcategoryDomain _subcategoryDomain;
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public SubcategoryApplication(

            ISubcategoryDomain subcategoryDomain,
            IUnitOfWork unitOfWork
            )
        {
            _subcategoryDomain = subcategoryDomain;
            _unitOfWork = unitOfWork;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<int> subAdd(SubcategoryDto subcategory)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<int> respuesta = new ResResponse<int>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();

                if (
                    //                                      //Validate data
                    SubcategoryAppValidator.isValidForAdd(subcategory, st, _unitOfWork)
                    )
                {
                    //                                      //Sort info and transform input data
                    var subcategoryEntity = AutoMapperConfig.mapper.Map<SubcategoryEntity>(subcategory);

                    int intPk = _subcategoryDomain.subAdd(subcategoryEntity);

                    respuesta.Data = intPk;
                    _unitOfWork.CommitTransaction();
                    _unitOfWork.DisposableTransaction();
                    _unitOfWork.DisposableContext();
                }
            }
            catch (Exception e)
            {
                respuesta.setException(e.Message);

                _unitOfWork.RollbackTransaction();
                _unitOfWork.DisposableTransaction();
                _unitOfWork.DisposableContext();
            }

            return respuesta;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<SubcategoryDto> subGet(int intPk)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<SubcategoryDto> respuesta = new ResResponse<SubcategoryDto>(st);
            try
            {
                if (
                    //                                      //Validate data
                    intPk > 0
                    )
                {
                    //                                      //Sort info and transform input data
                    SubcategoryEntity subcategory = _subcategoryDomain.subGet(intPk);
                    var categoryDto = AutoMapperConfig.mapper.Map<SubcategoryDto>(subcategory);

                    respuesta.Data= categoryDto;
                }
                else
                {
                    st.subSetDevError("Pk not valid");
                }
            }
            catch (Exception e)
            {
                respuesta.setException(e.Message);
            }

            return respuesta;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<List<SubcategoryDto>> subGetAll()
        {
            Status st = Status.stGetInitialOk();
            ResResponse<List<SubcategoryDto>> respuesta = new ResResponse<List<SubcategoryDto>>(st);
            try
            {
                //                                      //Sort info and transform input data
                List<SubcategoryEntity> listCategories = _subcategoryDomain.subGetAll();
                var listCategoriesDto = listCategories.Select(cat => 
                    AutoMapperConfig.mapper.Map<SubcategoryDto>(cat)).ToList();

                respuesta.Data = listCategoriesDto;
            }
            catch (Exception e)
            {
                respuesta.setException(e.Message);
            }

            return respuesta;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<Empty> subDelete(int intPk)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<Empty> respuesta = new ResResponse<Empty>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();
                SubcategoryBso category;
                if (
                    //                                      //exist the category
                    SubcategoryAppValidator.isValidForDelete(intPk, st, _unitOfWork, out category)
                    )
                {
                    _subcategoryDomain.subRemove(category);

                    _unitOfWork.CommitTransaction();
                    _unitOfWork.DisposableTransaction();
                    _unitOfWork.DisposableContext();
                }
            }
            catch (Exception e)
            {
                respuesta.setException(e.Message);

                _unitOfWork.RollbackTransaction();
                _unitOfWork.DisposableTransaction();
                _unitOfWork.DisposableContext();
            }

            return respuesta;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<Empty> subUpdate(SubcategoryDto subcategory)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<Empty> respuesta = new ResResponse<Empty>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();
                SubcategoryBso subcategoryBso;
                if (
                    //                                      //exist the category
                    SubcategoryAppValidator.isValidForUpdate(subcategory, st, _unitOfWork, out subcategoryBso)
                    )
                {
                    _subcategoryDomain.subUpdate(subcategory.Name, subcategory.Id, subcategoryBso);

                    _unitOfWork.CommitTransaction();
                    _unitOfWork.DisposableTransaction();
                    _unitOfWork.DisposableContext();
                }
            }
            catch (Exception e)
            {
                respuesta.setException(e.Message);

                _unitOfWork.RollbackTransaction();
                _unitOfWork.DisposableTransaction();
                _unitOfWork.DisposableContext();
            }

            return respuesta;
        }
    }
}
