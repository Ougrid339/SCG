using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query();

        IQueryable<TEntity> Read();

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity ReadFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> GetAll();

        List<TEntity> ReadAll();

        void Delete(TEntity entity);

        void Delete(List<TEntity> entities);

        TEntity Add(TEntity item);

        List<TEntity> Add(List<TEntity> items);

        //List<TEntity> BulkInsert(List<TEntity> items);
        List<TEntity> BulkInsert(List<TEntity> items);

        void BulkUpdate(List<TEntity> items);

        void BulkDelete(List<TEntity> items);

        bool Update(TEntity item);

        void ExecuteCommand(string cmd, List<SqlParameter> parameter);
    }
}