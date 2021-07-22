using DTO;
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
   public class UserRepository : Repository<User> 
    {
        public UserRepository(DbContextShopPakemon dbContext) : base(dbContext)
        {

        }  
    }
}
