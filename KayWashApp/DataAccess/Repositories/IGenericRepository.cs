using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public interface IGenericRepository<T> : IDisposable
    {
        T GetById(object id);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        IEnumerable<T> GetAll();

        T Insert(T item);

        T Update(object id, T item);

        void Delete(object id);
    }
}
