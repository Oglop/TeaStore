using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace TeaStore.Models
{
    public class TeaDatabaseContext : DbContext
    {
        public DbSet<Tea> Teas { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}