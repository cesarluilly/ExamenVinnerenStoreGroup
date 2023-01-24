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
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryDomain _categoryDomain;
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public CategoryApplication(

            ICategoryDomain categoryDomain,
            IUnitOfWork unitOfWork
            )
        {
            _categoryDomain = categoryDomain;
            _unitOfWork = unitOfWork;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<int> subAdd(CategoryDto category)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<int> respuesta = new ResResponse<int>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();

                if (
                    //                                      //Validate data
                    CategoryAppValidator.isValidForAdd(category, st)
                    )
                {
                    //                                      //Sort info and transform input data
                    var categoryEntity = AutoMapperConfig.mapper.Map<CategoryEntity>(category);

                    int intPk = _categoryDomain.subAdd(categoryEntity);

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
        public ResResponse<CategoryDto> subGet(int intPk)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<CategoryDto> respuesta = new ResResponse<CategoryDto>(st);
            try
            {
                if (
                    //                                      //Validate data
                    intPk > 0
                    )
                {
                    //                                      //Sort info and transform input data
                    CategoryEntity category = _categoryDomain.subGet(intPk);
                    var categoryDto = AutoMapperConfig.mapper.Map<CategoryDto>(category);

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
        public ResResponse<List<CategoryDto>> subGetAll()
        {
            Status st = Status.stGetInitialOk();
            ResResponse<List<CategoryDto>> respuesta = new ResResponse<List<CategoryDto>>(st);
            try
            {
                //                                      //Sort info and transform input data
                List<CategoryEntity> listCategories = _categoryDomain.subGetAll();
                var listCategoriesDto = listCategories.Select(cat => 
                    AutoMapperConfig.mapper.Map<CategoryDto>(cat)).ToList();

                respuesta.Data = listCategoriesDto;
            }
            catch (Exception e)
            {
                respuesta.setException(e.Message);
            }

            return respuesta;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<Empty> subRemove(int intPk)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<Empty> respuesta = new ResResponse<Empty>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();
                CategoryBso category;
                if (
                    //                                      //exist the category
                    CategoryAppValidator.isValidForDelete(intPk, st, _unitOfWork, out category)
                    )
                {
                    _categoryDomain.subRemove(category);

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
        public ResResponse<Empty> subUpdate(CategoryDto categoryDto)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<Empty> respuesta = new ResResponse<Empty>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();
                CategoryBso categoryBso;
                if (
                    //                                      //exist the category
                    CategoryAppValidator.isValidForUpdate(categoryDto, st, _unitOfWork, out categoryBso)
                    )
                {
                    _categoryDomain.subUpdate(categoryDto.Name, categoryDto.Id, categoryBso);

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
