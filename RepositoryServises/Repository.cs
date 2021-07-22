using DTO;
using EntityForDatabase;
using EntityForDatabase.Entity;
using IRepositoryServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryServises
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {

        protected readonly DbContextShopPokemon DbContext;
        protected readonly DbSet<T> Table;

        public Repository(DbContextShopPokemon dbContext ) 
        {
            DbContext = dbContext;
            Table = DbContext.Set<T>();
        }

        public Guid id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task Add(T entity)
        {
             await Table.AddAsync(entity);
        }


        public IQueryable<T> Get()
        {
            IQueryable<T> AllEntity = Table.Where(el => el.id != null);
            return AllEntity;
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            T entity = Table.Where(predicate).FirstOrDefault();
            return entity;
        }
        public void Update(T entity)
        {
            T Entitu = Table.Where(el => el.id == entity.id).FirstOrDefault();
            Entitu = entity;
            Table.Update(Entitu);
        }

    }
}
