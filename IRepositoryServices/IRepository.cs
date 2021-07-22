using DTO;
using EntityForDatabase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRepositoryServices
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task Add(T entity);

        IQueryable<T> Get();

        public T GetBy(Expression<Func<T, bool>> predicate);

        public void Update(T entity);



    }
}
 