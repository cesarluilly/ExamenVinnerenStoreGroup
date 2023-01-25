using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;
//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //CO-AUTHOR:  ().
//                                                          //DATE: January 22, 2023. 
namespace Vinneren.Storegp.Infraescructure.Interface
{
    //==================================================================================================================
    public interface IProductRepo<TEntity> : IRepositoryGenericTEntity<TEntity>
    {
        //**************************************************//GET\\*****************************************************
        public IQueryable<ProductEntity> GetByCategoryOrSubcategory(
            String strCategory_I, String strSubcategory);

        public IQueryable<ProductEntity> GetByRangeInventory(
            int intInitial, int intEnd);

        //**************************************************//ADD\\*****************************************************

        //**************************************************//UPDATE\\**************************************************

        //**************************************************//DELETE\\**************************************************

    }
}
