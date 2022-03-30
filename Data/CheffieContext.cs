#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheffie.Models;

namespace Cheffie.Data
{
    public class CheffieContext : DbContext
    {
        public CheffieContext (DbContextOptions<CheffieContext> options)
            : base(options)
        {
        }

        public DbSet<Cheffie.Models.Cook> Cook { get; set; }
        public DbSet<Cheffie.Models.Cook> Post { get; set; }
        public DbSet<Cheffie.Models.Post> Post_1 { get; set; }
    }
}
