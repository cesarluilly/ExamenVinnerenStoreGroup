using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Infraescructure.Data;
using Vinneren.Storegp.Infraescructure.Interface;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Infraescructure.Repository
{
    //==================================================================================================================
    public class InventoryProductRepo<TEntity> : IInventoryProductRepo<TEntity> where TEntity : class
    {
        private VinnContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private IRepositoryGenericTEntity<TEntity> _inventoryProductRepoGeneric;

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTOR.
        public InventoryProductRepo(

            VinnContext context_I,
            IUnitOfWork _unitOfWork_I
            )
        {
            _context = context_I;
            _unitOfWork = _unitOfWork_I;
            this.subInitializeRepoGenericTEntity();
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public void subInitializeRepoGenericTEntity()
        {
            if (_inventoryProductRepoGeneric == null)
                _inventoryProductRepoGeneric = new RepositoryGenericTEntity<TEntity>(_context);
        }

        //**************************************************//GET\\*****************************************************

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetAll()
        {
            return this._inventoryProductRepoGeneric.GetAll();
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetOneByPk(int intPk)
        {
            return this._inventoryProductRepoGeneric.GetOneByPk(intPk);
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetListFromListOfPks(List<int> data)
        {
            return this._inventoryProductRepoGeneric.GetListFromListOfPks(data);
        }

        //--------------------------------------------------------------------------------------------------------------
        public bool boolIsValidPk(int intPk)
        {
            int? intPkEmpSet = _context.Category.Where(ct => ct.Pk == intPk)
                .Select(cta => cta.Pk).FirstOrDefault();
            return intPkEmpSet != 0;
        }

        //**************************************************//ADD\\*****************************************************
        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------
        public void AddOne(TEntity data, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.AddOne(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void AddList(List<TEntity> data, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.AddList(data, boolSaveChanges);
        }

        //**************************************************//UPDATE\\**************************************************
        //                                                  //UPDATE From IRepositoryGenericTEntty
        //--------------------------------------------------------------------------------------------------------------
        public void UpdateOne(TEntity data, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.UpdateOne(data, boolSaveChanges);
        }

        //                                                  //UPDATE From IRepositoryGenericTEntty
        //--------------------------------------------------------------------------------------------------------------
        public void UpdateList(List<TEntity> data, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.UpdateList(data, boolSaveChanges);
        }

        //**************************************************//DELETE\\**************************************************
        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysical(TEntity data, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.DeleteOnePhysical(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysicalByPk(int intPk, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.DeleteOnePhysicalByPk(intPk, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysical(List<TEntity> data, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.DeleteListPhysical(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysicalByPk(List<int> darrintPk, bool boolSaveChanges = true)
        {
            _inventoryProductRepoGeneric.DeleteListPhysicalByPk(darrintPk, boolSaveChanges);
        }
    }
}
