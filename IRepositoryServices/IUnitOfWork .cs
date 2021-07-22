using EntityForDatabase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositoryServices
{
    
    public interface IUnitOfWork
    {
        IRepository<User> User { get; }
       
        Task<int> SaveChangesAsync();
    }
}
