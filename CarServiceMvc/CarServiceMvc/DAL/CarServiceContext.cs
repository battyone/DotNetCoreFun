using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceMvc.DAL
{
    public class CarServiceContext : DbContext
    {
        // DB connection properties injected automatically
        public CarServiceContext() {}

        // DB connection properties given explicitly (for Unit Tests)
        public CarServiceContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

    }
}
