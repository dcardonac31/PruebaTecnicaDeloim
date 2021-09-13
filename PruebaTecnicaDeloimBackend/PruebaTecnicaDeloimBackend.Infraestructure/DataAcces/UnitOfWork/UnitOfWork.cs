using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
namespace PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.UnitOfWork
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes
        private readonly DbContext _context;
        private bool _disposed = false;

        #endregion

        #region Constructor
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {

        }
        #endregion

        #region Methods
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            _context.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save() => _context.SaveChanges();

        public void Rollback() => _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

        #endregion

    }
}
