using EntityForDatabase;
using EntityForDatabase.Entity;
using IRepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServises
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        protected DbContextShopPakemon DbContext;
        private readonly IRepository<User> _User;

        public UnitOfWork(IRepository<User> user, DbContextShopPakemon dbContext)
        {
            DbContext = dbContext;
            _User = user;


        }

        public IRepository<User> User { get { return _User; } }


        public void Dispose()
        {
            DbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
