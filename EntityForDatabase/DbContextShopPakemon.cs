using EntityForDatabase.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityForDatabase
{
    public class DbContextShopPakemon : DbContext
    {
        public DbContextShopPakemon(DbContextOptions<DbContextShopPakemon> options) : base(options) 
        {

        }

       public DbSet<User> Users { get; set; }
    }
}
