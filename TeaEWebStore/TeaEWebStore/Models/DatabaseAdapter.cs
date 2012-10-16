using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeaEWebStore.Models
{
    public class DatabaseAdapter : DbContext
    {
        public DbSet<Tea> Teas { get; set; }
        public DbSet<TeaType> TeaTypes { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}