using LiteDB;
using RPGWriter.Models;
using System;
using System.IO;

namespace RPGWriter.Services
{
    public class UnitOfWork : IDisposable
    {
        private readonly LiteDatabase database;
    
        public ILiteCollection<Subject> Subjects => database.GetCollection<Subject>("subjects");

        public UnitOfWork()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "rpgwriter.db");
            database = new LiteDatabase(path);
        }

        public void Transaction(Action action)
        {
            database.BeginTrans();

            try
            {
                action.Invoke();
                database.Commit();
            }
            catch
            {
                database.Rollback();
                throw;
            }
        }

        public void SaveChanges()
        {
            // LiteDB的操作是自动提交的，所以你不需要在这里实现任何东西。
            // 但是，这个方法可以留作以后可能的用途，例如日志记录等。
        }

        public void Dispose() => database?.Dispose();
    }
}
