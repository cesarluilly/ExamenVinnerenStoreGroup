using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Infraescructure.Data;
using Vinneren.Storegp.Infraescructure.Interface;

namespace Vinneren.Storegp.Infraescructure.Repository
{
    //==================================================================================================================
    public class RepositoryGenericTEntity<TEntity> : IRepositoryGenericTEntity<TEntity> where TEntity : class
    {
        private VinnContext _context;
        private DbSet<TEntity> _dbSet;
        private String _strTableName;
        private String _strPrimaryKey;

        //--------------------------------------------------------------------------------------------------------------
        public RepositoryGenericTEntity(VinnContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();

            var model = _dbSet.GetService<VinnContext>().Model;
            var entityType = model.FindEntityType(typeof(TEntity));
            _strTableName = entityType.GetTableName();
            _strPrimaryKey = entityType.FindPrimaryKey().Properties.First().GetColumnName();
        }

        //**************************************************//GET\\*****************************************************

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetOneByPk(int intPk)
        {
            var a = _dbSet.FromSqlRaw($"SELECT * FROM {_strTableName} WHERE {_strPrimaryKey} = {intPk}");
            return a;
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetListFromListOfPks(List<int> data)
        {
            if (data.Count > 0)
            {
                String strInInstruction = "(";
                foreach (var intPk in data)
                {
                    strInInstruction = strInInstruction + $"{intPk}, ";
                }
                strInInstruction = strInInstruction.Remove(strInInstruction.Length - 2, 2);
                strInInstruction = strInInstruction + ")";
                return _dbSet.FromSqlRaw($"SELECT * FROM {_strTableName} WHERE {_strPrimaryKey} IN {strInInstruction}");
            }

            return _dbSet.FromSqlRaw($"SELECT * FROM {_strTableName} WHERE {_strPrimaryKey} IN (-10000)");
        }

        //--------------------------------------------------------------------------------------------------------------
        public IQueryable<TEntity> GetAll() => _dbSet.AsQueryable();

        //**************************************************//ADD\\*****************************************************

        //--------------------------------------------------------------------------------------------------------------
        public void AddOne(TEntity data, bool boolSaveChanges = true)
        {
            _dbSet.Add(data);
            if (boolSaveChanges)
                this._context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void AddList(List<TEntity> data, bool boolSaveChanges = true) {
            _dbSet.AddRange(data);

            if (boolSaveChanges)
                this._context.SaveChanges();
        } 

        //**************************************************//UPDATE\\**************************************************

        //--------------------------------------------------------------------------------------------------------------
        public void UpdateOne(TEntity data, bool boolSaveChanges = true)
        {
            _context.Update(data);
            if (boolSaveChanges)
                this._context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void UpdateList(List<TEntity> data, bool boolSaveChanges = true)
        {
            _context.UpdateRange(data);
            if (boolSaveChanges)
                this._context.SaveChanges();
        }

        //**************************************************//DELETE\\**************************************************

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysical(TEntity data, bool boolSaveChanges = true)
        {
            _context.Remove(data);
            if (boolSaveChanges)
                this._context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteOnePhysicalByPk(int intPk, bool boolSaveChanges = true)
        {
            var dataToDelete = _dbSet.Find(intPk);
            _context.Remove(dataToDelete);
            if (boolSaveChanges)
                this._context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysical(List<TEntity> data, bool boolSaveChanges = true)
        {
            _context.RemoveRange(data);
            if (boolSaveChanges)
                this._context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------------------------------
        public void DeleteListPhysicalByPk(List<int> darrintPk, bool boolSaveChanges = true)
        {
            foreach (int intPk in darrintPk)
            {
                this.DeleteOnePhysicalByPk(intPk);
            }
            if (boolSaveChanges)
                this._context.SaveChanges();
        }
    }

    //==================================================================================================================
}
