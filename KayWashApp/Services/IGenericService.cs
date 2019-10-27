using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Services
{
    public interface IGenericService<T>
    {
        T GetById(long id);

        IEnumerable<T> GetAll();

        T Insert(T item);

        T Update(long id, T item);

        void Delete(long id);
    }
}
