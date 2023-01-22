using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinneren.Storegp.Infraescructure.Interface
{
    //==================================================================================================================
    public interface IRepositoryGenericTEntity<TEntity>
    {
        //**************************************************//GET\\*****************************************************
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetOneByPk(int intPk);
        IQueryable<TEntity> GetListFromListOfPks(List<int> data);

        //**************************************************//ADD\\*****************************************************
        void AddOne(TEntity data, bool boolSaveChanges = true);
        void AddList(List<TEntity> data, bool boolSaveChanges = true);

        //**************************************************//UPDATE\\**************************************************
        void UpdateOne(TEntity data, bool boolSaveChanges = true);
        void UpdateList(List<TEntity> data, bool boolSaveChanges = true);

        //**************************************************//DELETE\\**************************************************
        void DeleteOnePhysical(TEntity data, bool boolSaveChanges = true);
        void DeleteOnePhysicalByPk(int intId, bool boolSaveChanges = true);
        void DeleteListPhysical(List<TEntity> data, bool boolSaveChanges = true);
        void DeleteListPhysicalByPk(List<int> darrintPk, bool boolSaveChanges = true);

    }

    //==================================================================================================================
}
