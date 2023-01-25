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
    public interface IInventoryProductDomain
    {
        public int subAdd(InventoryProductEntity inventoryProductEntity);
        public InventoryProductEntity subGet(int intPk);
        public List<InventoryProductEntity> subGetAll();
        public Empty subRemove(InventoryProductBso inventoryProductBsoToDelete);
        public Empty subUpdate(int intUnits, String strNote, InventoryProductBso inventoryProductBsoToUpdate);
    }

    //==================================================================================================================
}
