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
    public class InventoryDomain : IInventoryDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        //--------------------------------------------------------------------------------------------------------------
        public InventoryDomain(

            IUnitOfWork unitOfWork_I
            )
        {
            _unitOfWork= unitOfWork_I;
        }

        //--------------------------------------------------------------------------------------------------------------
        public int subAdd(InventoryEntity inventoryEntity)
        {
            _unitOfWork.InventoryRepo.AddOne(inventoryEntity);
            _unitOfWork.Save();
            return inventoryEntity.Pk;
        }

        //--------------------------------------------------------------------------------------------------------------
        public InventoryEntity subGet(int intPk)
        {
            return _unitOfWork.InventoryRepo.GetOneByPk(intPk).FirstOrDefault();
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<InventoryEntity> subGetAll()
{
            return _unitOfWork.InventoryRepo.GetAll().ToList();
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subRemove(InventoryBso inventoryBsoToDelete)
        {
            inventoryBsoToDelete.subDeleteAtDB();
            return null;
        }

        //--------------------------------------------------------------------------------------------------------------
        public Empty subUpdate(String strNote, InventoryBso inventorybsoToUpdate)
        {
            inventorybsoToUpdate.Note = strNote;
            inventorybsoToUpdate.subUpdateAtDB();

            return null;
        }
    }
}
