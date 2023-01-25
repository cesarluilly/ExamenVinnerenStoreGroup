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
    public class ProductApplication : IProductApplication
    {
        private readonly IProductDomain _productDomain;
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public ProductApplication(

            IProductDomain productDomain,
            IUnitOfWork unitOfWork
            )
        {
            _productDomain = productDomain;
            _unitOfWork = unitOfWork;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<int> subAdd(ProductDto productDto)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<int> respuesta = new ResResponse<int>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();

                if (
                    //                                      //Validate data
                    ProductAppValidator.isValidForAdd(productDto, st)
                    )
                {
                    //                                      //Sort info and transform input data
                    var entity = AutoMapperConfig.mapper.Map<ProductEntity>(productDto);

                    int intPk = _productDomain.subAdd(entity);

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
        public ResResponse<ProductDto> subGet(int intPk)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<ProductDto> respuesta = new ResResponse<ProductDto>(st);
            try
            {
                if (
                    //                                      //Validate data
                    intPk > 0
                    )
                {
                    //                                      //Sort info and transform input data
                    ProductEntity entity = _productDomain.subGet(intPk);
                    var dto = AutoMapperConfig.mapper.Map<ProductDto>(entity);

                    respuesta.Data = dto;
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
        public ResResponse<List<ProductDto>> subGetAll()
        {
            Status st = Status.stGetInitialOk();
            ResResponse<List<ProductDto>> respuesta = new ResResponse<List<ProductDto>>(st);
            try
            {
                //                                      //Sort info and transform input data
                List<ProductEntity> listentitys = _productDomain.subGetAll();
                var listCategoriesDto = listentitys.Select(cat => 
                    AutoMapperConfig.mapper.Map<ProductDto>(cat)).ToList();

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
                ProductBso bso;
                if (
                    //                                      //exist the category
                    ProductAppValidator.isValidForDelete(intPk, st, _unitOfWork, out bso)
                    )
                {
                    _productDomain.subRemove(bso);

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
        public ResResponse<Empty> subUpdate(ProductDto productDto)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<Empty> respuesta = new ResResponse<Empty>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();
                ProductBso bso;
                if (
                    //                                      //exist the category
                    ProductAppValidator.isValidForUpdate(productDto, st, _unitOfWork, out bso)
                    )
                {
                    _productDomain.subUpdate(productDto.Name, productDto.NumMaterial, bso);

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
