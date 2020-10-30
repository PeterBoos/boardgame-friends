using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public interface IDbServiceBase<T> where T : class
    {
        Task<EntityEntry<T>> Create(T entity);
        Task<EntityEntry<T>> Delete(T entity);
        Task<EntityEntry<T>> Update(T entity);
        Task<IEnumerable<T>> GetAll();

    }
}
