using System;

namespace PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        new void Dispose();
        int Save();
        void Rollback();
    }
}
