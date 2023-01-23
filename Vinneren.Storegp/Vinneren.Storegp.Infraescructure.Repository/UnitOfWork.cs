using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
using Vinneren.Storegp.Infraescructure.Data;
using Vinneren.Storegp.Infraescructure.Interface;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 22, 2023. 
namespace Vinneren.Storegp.Infraescructure.Repository
{
    //==================================================================================================================
    public class UnitOfWork : IUnitOfWork
    {
        private VinnContext _context;
        private Object _dbContextTransaction;

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTOR.
        public UnitOfWork(VinnContext context)
        {
            _context = context;
        }

        //**************************************************//VinContext\\**********************************************
        
        //                                                  //CategoryRepo
        private ICategoryRepo<CategoryEntity> _categoryRepo;
        public ICategoryRepo<CategoryEntity> CategoryRepo
        {
            get
            {
                return _categoryRepo == null ?
                    _categoryRepo = new CategoryRepo<CategoryEntity>(_context, this) :
                    _categoryRepo;
            }
        }

        //                                                  //inventoryRepo
        private IInventoryRepo<InventoryEntity> _inventoryRepo;
        public IInventoryRepo<InventoryEntity> InventoryRepo
        {
            get
            {
                return _inventoryRepo == null ?
                    _inventoryRepo = new InventoryRepo<InventoryEntity>(_context, this) :
                    _inventoryRepo;
            }
        }

        //                                                  //InventoryProductRepo
        private IInventoryProductRepo<InventoryProductEntity> _inventoryProductRepo;
        public IInventoryProductRepo<InventoryProductEntity> InventoryProductRepo
        {
            get
            {
                return _inventoryProductRepo == null ?
                    _inventoryProductRepo = new InventoryProductRepo<InventoryProductEntity>(_context, this) :
                    _inventoryProductRepo;
            }
        }

        //                                                  //EmployeeSettingsRepoC
        private IProductRepo<ProductEntity> _productRepo;
        public IProductRepo<ProductEntity> ProductRepo
        {
            get
            {
                return _productRepo == null ?
                    _productRepo = new ProductRepo<ProductEntity>(_context, this) :
                    _productRepo;
            }
        }

        //                                                  //EmployeeSettingsRepoC
        private ISubcategoryRepo<SubcategoryEntity> _subcategoryRepo;
        public ISubcategoryRepo<SubcategoryEntity> SubcategoryRepo
        {
            get
            {
                return _subcategoryRepo == null ?
                    _subcategoryRepo = new SubcategoryRepo<SubcategoryEntity>(_context, this) :
                    _subcategoryRepo;
            }
        }

        //**************************************************//OPERATION DATABASE ODYSSEY2DB\\***************************

        //--------------------------------------------------------------------------------------------------------------
        public void Save()
        {
            _context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void StartTransaction()
        {
            if (_dbContextTransaction == null)
                _dbContextTransaction = _context.Database.BeginTransaction();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void CommitTransaction()
        {
            if (_dbContextTransaction != null)
                ((IDbContextTransaction)_dbContextTransaction).Commit();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void RollbackTransaction()
        {
            if (_dbContextTransaction != null)
                ((IDbContextTransaction)_dbContextTransaction).Rollback();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DisposableTransaction()
        {
            if (_dbContextTransaction != null)
                ((IDbContextTransaction)_dbContextTransaction).Dispose();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DisposableContext()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
