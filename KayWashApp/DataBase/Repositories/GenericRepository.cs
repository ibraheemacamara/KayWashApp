using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KayWashApp.DataBase.Repositories
{
    public abstract class GenericRepository<TC, TE, TBE> : IGenericRepository<TBE>
        where TC : DbContext, new()
        where TE : class
        where TBE : class
    {
        protected TC DataContext { get; set; }
        protected IMapper Mapper { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected GenericRepository(TC context)
        {
            DataContext = context;
            ConfigureMapper();
        }

        // Mapping could be probably refactored out to some static class wrapping AutoMapper'e Mapper
        // and injecting initialized IMapper via constructor
        // (see https://lostechies.com/jimmybogard/2016/01/21/removing-the-static-api-from-automapper/)
        protected abstract void ConfigureMapper();

        public void Delete(object id)
        {
            var dto = DataContext.Set<TE>().Find(id);
            DataContext.Set<TE>().Remove(dto);
            DataContext.SaveChanges();
        }

        public IEnumerable<TBE> GetAll()
        {
            return DataContext.Set<TE>().ProjectTo<TBE>(Mapper.ConfigurationProvider).ToArray();
        }

        public TBE GetById(object id)
        {
            return Mapper.Map<TBE>(DataContext.Set<TE>().Find(id));
        }

        public TBE Insert(TBE item)
        {
            TE dto = Mapper.Map<TE>(item);
            DataContext.Set<TE>().Add(dto);
            DataContext.SaveChanges();
            return Mapper.Map<TBE>(dto);
        }

        public TBE Update(object id, TBE item)
        {
            if (item == null)
                return null;

            TE existing = DataContext.Set<TE>().Find(id);
            if (existing != null)
            {
                TE dto = Mapper.Map<TE>(item);
                DataContext.Entry(existing).CurrentValues.SetValues(dto);
                DataContext.SaveChanges();
            }

            return Mapper.Map<TBE>(existing);
        }

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
        }
    }
}
