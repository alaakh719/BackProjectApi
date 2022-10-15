using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opthion):base(opthion)
        {

        }

      public  DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
