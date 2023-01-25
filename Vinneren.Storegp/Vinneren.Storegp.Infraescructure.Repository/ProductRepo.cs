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
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Infraescructure.Repository
{
    //==================================================================================================================
    public class ProductRepo<TEntity> : IProductRepo<TEntity> where TEntity : class
    {
        private VinnContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private IRepositoryGenericTEntity<TEntity> _productRepoGeneric;

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTOR.
        public ProductRepo(

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
            if (_productRepoGeneric == null)
                _productRepoGeneric = new RepositoryGenericTEntity<TEntity>(_context);
        }

        //**************************************************//GET\\*****************************************************

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetAll()
        {
            return this._productRepoGeneric.GetAll();
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetOneByPk(int intPk)
        {
            return this._productRepoGeneric.GetOneByPk(intPk);
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetListFromListOfPks(List<int> data)
        {
            return this._productRepoGeneric.GetListFromListOfPks(data);
        }

        //--------------------------------------------------------------------------------------------------------------
        public bool boolIsValidPk(int intPk)
        {
            int? intPkEmpSet = _context.Category.Where(ct => ct.Pk == intPk)
                .Select(cta => cta.Pk).FirstOrDefault();
            return intPkEmpSet != 0;
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<ProductEntity> GetByCategoryOrSubcategory(
            String strCategory_I, String strSubcategory)
        {
            var iqy = (from prod in _unitOfWork.context.Product 
                       join subCateg in _unitOfWork.context.Subcategory 
                       on prod.PkSubCategory equals subCateg.Pk
                       join cat in _unitOfWork.context.Category
                       on subCateg.PkCategory equals cat.Pk
                       where cat.Name.Contains(strCategory_I) ||
                       subCateg.Name.Contains(strSubcategory)
                       select prod);
            return iqy;
        }

        //**************************************************//ADD\\*****************************************************
        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------
        public void AddOne(TEntity data, bool boolSaveChanges = true)
        {
            _productRepoGeneric.AddOne(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void AddList(List<TEntity> data, bool boolSaveChanges = true)
        {
            _productRepoGeneric.AddList(data, boolSaveChanges);
        }

        //**************************************************//UPDATE\\**************************************************
        //                                                  //UPDATE From IRepositoryGenericTEntty
        //--------------------------------------------------------------------------------------------------------------
        public void UpdateOne(TEntity data, bool boolSaveChanges = true)
        {
            _productRepoGeneric.UpdateOne(data, boolSaveChanges);
        }

        //                                                  //UPDATE From IRepositoryGenericTEntty
        //--------------------------------------------------------------------------------------------------------------
        public void UpdateList(List<TEntity> data, bool boolSaveChanges = true)
        {
            _productRepoGeneric.UpdateList(data, boolSaveChanges);
        }

        //**************************************************//DELETE\\**************************************************
        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysical(TEntity data, bool boolSaveChanges = true)
        {
            _productRepoGeneric.DeleteOnePhysical(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysicalByPk(int intPk, bool boolSaveChanges = true)
        {
            _productRepoGeneric.DeleteOnePhysicalByPk(intPk, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysical(List<TEntity> data, bool boolSaveChanges = true)
        {
            _productRepoGeneric.DeleteListPhysical(data, boolSaveChanges);
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysicalByPk(List<int> darrintPk, bool boolSaveChanges = true)
        {
            _productRepoGeneric.DeleteListPhysicalByPk(darrintPk, boolSaveChanges);
        }
    }
}
