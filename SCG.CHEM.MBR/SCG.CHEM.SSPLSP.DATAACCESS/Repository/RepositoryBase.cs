using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NLog;
using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

//using EFCore.BulkExtensions;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected EntitiesContext _context;
        protected EntitiesReadContext _readContext;

        public RepositoryBase(EntitiesContext context, EntitiesReadContext readConext)
        {
            this._context = context;
            this._readContext = readConext;
            this._readContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Read()
        {
            return _readContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public TEntity ReadFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _readContext.Set<TEntity>().Where(predicate).AsNoTracking().FirstOrDefault();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public List<TEntity> ReadAll()
        {
            return _readContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Delete(List<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        public TEntity Add(TEntity item)
        {
            try
            {
                _context.Set<TEntity>().Add(item);
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var _logger = NLog.LogManager.GetCurrentClassLogger();
                _logger.Error(ex, $"[LINQ][Add]{item.ToJSON()}");
                throw ex;
            }
        }

        public List<TEntity> Add(List<TEntity> items)
        {
            try
            {
                foreach (var item in items)
                {
                    if (_context.Entry(item).State != EntityState.Detached)
                        _context.Entry(item).State = EntityState.Detached;
                }
                _context.Set<TEntity>().AddRange(items);
                return items;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var _logger = NLog.LogManager.GetCurrentClassLogger();
                _logger.Error(ex, $"[LINQ][AddRange]{items.ToJSON()}");
                throw ex;
            }
        }

        //public List<TEntity> BulkInsert(List<TEntity> items)
        //{
        //    try
        //    {
        //        _context.BulkInsert(items);
        //        return items;
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        var _logger = NLog.LogManager.GetCurrentClassLogger();
        //        _logger.Error(ex, $"[LINQ][BulkInsert]{items.ToJSON()}");
        //        throw ex;

        //    }
        //}

        public List<TEntity> BulkInsert(List<TEntity> items)
        {
            try
            {
                _context.BulkInsert(items);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var _logger = NLog.LogManager.GetCurrentClassLogger();
                _logger.Error(ex, $"[LINQ][AddRange]{items.ToJSON()}");
                throw ex;
            }
            return items;
        }

        public void BulkUpdate(List<TEntity> items)
        {
            try
            {
                _context.BulkUpdate(items);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var _logger = NLog.LogManager.GetCurrentClassLogger();
                _logger.Error(ex, $"[LINQ][AddRange]{items.ToJSON()}");
                throw ex;
            }
        }

        public void BulkDelete(List<TEntity> items)
        {
            try
            {
                _context.BulkDelete(items);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var _logger = NLog.LogManager.GetCurrentClassLogger();
                _logger.Error(ex, $"[LINQ][AddRange]{items.ToJSON()}");
                throw ex;
            }
        }

        public bool Update(TEntity item)
        {
            int countFail = 1;
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    _context.Entry(item).State = EntityState.Modified;
                    countFail++;
                    return true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                    if (countFail > 100)
                    {
                        var _logger = NLog.LogManager.GetCurrentClassLogger();
                        _logger.Error(ex, $"[LINQ][Update]{item.ToJSON()}");
                        throw ex;
                    }
                }
            } while (saveFailed);
            return saveFailed;
        }

        public void ExecuteCommand(string cmd, List<SqlParameter> parameters)
        {
            using (var command = _context.DbConnenct.CreateCommand())
            {
                command.CommandText = cmd;

                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);

                command.CommandTimeout = 300;
                _context.Database.OpenConnection();
                //command.ExecuteReader();
                command.ExecuteNonQuery();

                command.Dispose();
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}