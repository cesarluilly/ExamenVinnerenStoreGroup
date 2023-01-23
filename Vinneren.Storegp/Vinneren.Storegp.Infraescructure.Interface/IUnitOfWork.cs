using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Infraescructure.Data;

namespace Vinneren.Storegp.Infraescructure.Interface
{
    //==================================================================================================================
    public interface IUnitOfWork
    {
        //**************************************************//VinnerenContex\\******************************************

        public ICategoryRepo<CategoryEntity> CategoryRepo { get; }
        public IInventoryRepo<InventoryEntity> InventoryRepo { get; }
        public IInventoryProductRepo<InventoryProductEntity> InventoryProductRepo { get; }
        public IProductRepo<ProductEntity> ProductRepo { get; }
        public ISubcategoryRepo<SubcategoryEntity> SubcategoryRepo { get; }

        //**************************************************//OPERATION DATABASE ODYSSEY2DB\\***************************
        public VinnContext context { get; }
        public void Save();
        public void StartTransaction();
        public void CommitTransaction();
        public void RollbackTransaction();
        public void DisposableTransaction();
        public void DisposableContext();
    }
}
