using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Bso.BusinessClass;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Domain.Interface;
using Vinneren.Storegp.Infraescructure.Interface;
using Vinneren.Storegp.Transversal.Common;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 27, 2022. 
namespace Vinneren.Storegp.Domain.Core
{
    //==================================================================================================================
    public class InventoryProductDomain : IInventoryProductDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public InventoryProductDomain(

            IUnitOfWork unitOfWork_I
            )
        {
            _unitOfWork= unitOfWork_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        public int subAdd(InventoryProductEntity inventoryProductEntity)
        {
            _unitOfWork.InventoryProductRepo.AddOne(inventoryProductEntity);
            _unitOfWork.Save();
            return inventoryProductEntity.Pk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public InventoryProductEntity subGet(int intPk)
        {
            return _unitOfWork.InventoryProductRepo.GetOneByPk(intPk).FirstOrDefault();
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<InventoryProductEntity> subGetAll()
        {
            return _unitOfWork.InventoryProductRepo.GetAll().ToList();
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subRemove(InventoryProductBso inventoryProductBsoToDelete)
        {
            inventoryProductBsoToDelete.subDeleteAtDB();
            return null;
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subUpdate(int intUnits, String strNote, InventoryProductBso inventoryProductBsoToUpdate)
        {
            inventoryProductBsoToUpdate.Units = intUnits;
            inventoryProductBsoToUpdate.Note = strNote;
            inventoryProductBsoToUpdate.subUpdateAtDB();

            return null;
        }
    }
}
