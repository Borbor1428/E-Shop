using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmptyLayer.Entities;
using EntityLayer.Entities;

namespace DataAccessLayer.Context
{
    public class DataContext:DbContext
    {

        public DbSet<Card>Cards { get; set;  }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

    }

}
