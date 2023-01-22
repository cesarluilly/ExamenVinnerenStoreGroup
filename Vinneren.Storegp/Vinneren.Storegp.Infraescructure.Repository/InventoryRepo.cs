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
    public class InventoryRepo<TEntity> : IInventoryRepo<TEntity> where TEntity : class
    {
        private VinnContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private IRepositoryGenericTEntity<TEntity> _inventoryRepoGeneric;

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTOR.
        public InventoryRepo(

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
            if (_inventoryRepoGeneric == null)
                _inventoryRepoGeneric = new RepositoryGenericTEntity<TEntity>(_context);
        }

        //**************************************************//GET\\*****************************************************

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetAll()
        {
            return this._inventoryRepoGeneric.GetAll();
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetOneByPk(int intPk)
        {
            return this._inventoryRepoGeneric.GetOneByPk(intPk);
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetListFromListOfPks(List<int> data)
        {
            return this._inventoryRepoGeneric.GetListFromListOfPks(data);
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
            _inventoryRepoGeneric.AddOne(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void AddList(List<TEntity> data, bool boolSaveChanges = true)
        {
            _inventoryRepoGeneric.AddList(data, boolSaveChanges);
        }

        //**************************************************//UPDATE\\**************************************************
        //                                                  //UPDATE From IRepositoryGenericTEntty
        //--------------------------------------------------------------------------------------------------------------
        public void UpdateOne(TEntity data, bool boolSaveChanges = true)
        {
            _inventoryRepoGeneric.UpdateOne(data, boolSaveChanges);
        }

        //                                                  //UPDATE From IRepositoryGenericTEntty
        //--------------------------------------------------------------------------------------------------------------
        public void UpdateList(List<TEntity> data, bool boolSaveChanges = true)
        {
            _inventoryRepoGeneric.UpdateList(data, boolSaveChanges);
        }

        //**************************************************//DELETE\\**************************************************
        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysical(TEntity data, bool boolSaveChanges = true)
        {
            _inventoryRepoGeneric.DeleteOnePhysical(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysicalByPk(int intPk, bool boolSaveChanges = true)
        {
            _inventoryRepoGeneric.DeleteOnePhysicalByPk(intPk, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysical(List<TEntity> data, bool boolSaveChanges = true)
        {
            _inventoryRepoGeneric.DeleteListPhysical(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysicalByPk(List<int> darrintPk, bool boolSaveChanges = true)
        {
            _inventoryRepoGeneric.DeleteListPhysicalByPk(darrintPk, boolSaveChanges);
        }
    }
}
