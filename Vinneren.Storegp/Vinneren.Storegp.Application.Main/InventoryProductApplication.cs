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
    public class InventoryProductApplication : IInventoryProductApplication
    {
        private readonly IInventoryProductDomain _inventoryProductDomain;
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public InventoryProductApplication(

            IInventoryProductDomain inventoryProductDomain,
            IUnitOfWork unitOfWork
            )
        {
            _inventoryProductDomain = inventoryProductDomain;
            _unitOfWork = unitOfWork;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<int> subAdd(InventoryProductDto inventoryProductDto)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<int> respuesta = new ResResponse<int>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();

                if (
                    //                                      //Validate data
                    InventoryProductAppValidator.isValidForAdd(inventoryProductDto, _unitOfWork, st)
                    )
                {
                    //                                      //Sort info and transform input data
                    var entity = AutoMapperConfig.mapper.Map<InventoryProductEntity>(inventoryProductDto);

                    int intPk = _inventoryProductDomain.subAdd(entity);

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
        public ResResponse<InventoryProductDto> subGet(int intPk)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<InventoryProductDto> respuesta = new ResResponse<InventoryProductDto>(st);
            try
            {
                if (
                    //                                      //Validate data
                    intPk > 0
                    )
                {
                    //                                      //Sort info and transform input data
                    InventoryProductEntity entity = _inventoryProductDomain.subGet(intPk);
                    var dto = AutoMapperConfig.mapper.Map<InventoryProductDto>(entity);

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
        public ResResponse<List<InventoryProductDto>> subGetAll()
        {
            Status st = Status.stGetInitialOk();
            ResResponse<List<InventoryProductDto>> respuesta = new ResResponse<List<InventoryProductDto>>(st);
            try
            {
                //                                      //Sort info and transform input data
                List<InventoryProductEntity> listentitys = _inventoryProductDomain.subGetAll();
                var listCategoriesDto = listentitys.Select(cat => 
                    AutoMapperConfig.mapper.Map<InventoryProductDto>(cat)).ToList();

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
                InventoryProductBso bso;
                if (
                    //                                      //exist the category
                    InventoryProductAppValidator.isValidForDelete(intPk, st, _unitOfWork, out bso)
                    )
                {
                    _inventoryProductDomain.subRemove(bso);

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
        public ResResponse<Empty> subUpdate(InventoryProductDto inventoryProductDto)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<Empty> respuesta = new ResResponse<Empty>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();
                InventoryProductBso bso;
                if (
                    //                                      //exist the category
                    InventoryProductAppValidator.isValidForUpdate(inventoryProductDto, st, _unitOfWork, out bso)
                    )
                {
                    _inventoryProductDomain.subUpdate(inventoryProductDto.Units, inventoryProductDto.Note, bso);

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
