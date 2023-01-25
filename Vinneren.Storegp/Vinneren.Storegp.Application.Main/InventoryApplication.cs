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
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryDomain _inventoryDomain;
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public InventoryApplication(

            IInventoryDomain inventoryDomain,
            IUnitOfWork unitOfWork
            )
        {
            _inventoryDomain = inventoryDomain;
            _unitOfWork = unitOfWork;
        }

        //--------------------------------------------------------------------------------------------------------------
        public ResResponse<int> subAdd(InventoryDto inventoryDto)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<int> respuesta = new ResResponse<int>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();

                if (
                    //                                      //Validate data
                    InventoryAppValidator.isValidForAdd(inventoryDto, st)
                    )
                {
                    //                                      //Sort info and transform input data
                    var entity = AutoMapperConfig.mapper.Map<InventoryEntity>(inventoryDto);

                    int intPk = _inventoryDomain.subAdd(entity);

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
        public ResResponse<InventoryDto> subGet(int intPk)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<InventoryDto> respuesta = new ResResponse<InventoryDto>(st);
            try
            {
                if (
                    //                                      //Validate data
                    intPk > 0
                    )
                {
                    //                                      //Sort info and transform input data
                    InventoryEntity entity = _inventoryDomain.subGet(intPk);
                    var dto = AutoMapperConfig.mapper.Map<InventoryDto>(entity);

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
        public ResResponse<List<InventoryDto>> subGetAll()
        {
            Status st = Status.stGetInitialOk();
            ResResponse<List<InventoryDto>> respuesta = new ResResponse<List<InventoryDto>>(st);
            try
            {
                //                                      //Sort info and transform input data
                List<InventoryEntity> listentitys = _inventoryDomain.subGetAll();
                var listCategoriesDto = listentitys.Select(cat => 
                    AutoMapperConfig.mapper.Map<InventoryDto>(cat)).ToList();

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
                InventoryBso bso;
                if (
                    //                                      //exist the category
                    InventoryAppValidator.isValidForDelete(intPk, st, _unitOfWork, out bso)
                    )
                {
                    _inventoryDomain.subRemove(bso);

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
        public ResResponse<Empty> subUpdate(InventoryDto inventoryDto)
        {
            Status st = Status.stGetInitialOk();
            ResResponse<Empty> respuesta = new ResResponse<Empty>(st);
            try
            {
                //                                          //Init transaction DB.
                _unitOfWork.StartTransaction();
                InventoryBso bso;
                if (
                    //                                      //exist the category
                    InventoryAppValidator.isValidForUpdate(inventoryDto, st, _unitOfWork, out bso)
                    )
                {
                    _inventoryDomain.subUpdate(inventoryDto.Note, bso);

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
