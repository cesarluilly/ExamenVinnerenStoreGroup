using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Transversal.Common;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  (-).
//                                                          //DATE: January 27, 2023. 
namespace Vinneren.Storegp.Application.Interface
{
    //==================================================================================================================
    public interface IInventoryApplication
    {
        public ResResponse<int> subAdd(InventoryDto inventoryDto);
        public ResResponse<Empty> subUpdate(InventoryDto inventoryDto);
        public ResResponse<InventoryDto> subGet(int intPk);
        public ResResponse<List<InventoryDto>> subGetAll();
        public ResResponse<Empty> subDelete(int intPk);
    }

    //==================================================================================================================
}
