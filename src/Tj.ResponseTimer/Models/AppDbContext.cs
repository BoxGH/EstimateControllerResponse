using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tj.ResponseTimer.Models
{
    public class AppDbContext : DbContext
    {
       public DbSet<RequestResponseTime> Rrt { get; set; }
       public DbSet<SomeDataClassForView> Sdcfv { get; set; }
       public DbSet<ForTable> Ftdb { get; set; }
    }
}
