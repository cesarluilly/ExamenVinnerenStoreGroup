using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Bso.BusinessClass;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Transversal.Common;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 27, 2023. 
namespace Vinneren.Storegp.Domain.Interface
{
    //==================================================================================================================
    public interface IInventoryDomain
    {
        public int subAdd(InventoryEntity inventoryEntity);
        public InventoryEntity subGet(int intPk);
        public List<InventoryEntity> subGetAll();
        public Empty subRemove(InventoryBso inventoryBsoToDelete);
        public Empty subUpdate(String strNote, InventoryBso inventorybsoToUpdate);
    }

    //==================================================================================================================
}
