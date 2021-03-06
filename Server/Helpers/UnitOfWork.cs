using System;
using System.Data.SqlClient;
using QuanLyNongTrai.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QuanLyNongTrai.Model;
using QuanLyNongTrai.Model.Entity;
using QuanLyNongTrai.Repository;

namespace QuanLyNongTrai.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private static DbContext _dbContext = null;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public void SaveChanges()
        {
            NewMethod();
        }

        private static void NewMethod()
        {
            _dbContext.SaveChanges();
        }

        public void Commit(){
            if(_transaction == null)
                return;
            _transaction.Commit();
        }

        public void RollBack()
        {
            if(_transaction != null)
                _transaction.Rollback();
        }

        public void Dispose()
        {
            if(_transaction != null)
                _transaction.Dispose();
        }

        public void BeginTransaction()
        {
            if (_dbContext.Database.CurrentTransaction == null)
                _transaction = _dbContext.Database.BeginTransaction();
            else
                _transaction = _dbContext.Database.CurrentTransaction;
        }
    }
}