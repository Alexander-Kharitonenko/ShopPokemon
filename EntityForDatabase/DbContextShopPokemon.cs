using EntityForDatabase.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityForDatabase
{
    public class DbContextShopPokemon : DbContext
    {
        public DbContextShopPokemon(DbContextOptions<DbContextShopPokemon> options) : base(options) 
        {

        }

       public DbSet<User> Users { get; set; }
    }
}
