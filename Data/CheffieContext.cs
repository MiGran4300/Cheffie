#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheffie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cheffie.Data
{
    public class CheffieContext : IdentityDbContext<IdentityUser>
    {
        public CheffieContext (DbContextOptions<CheffieContext> options)
            : base(options)
        {
        }

        public DbSet<Cheffie.Models.Cook> Cook { get; set; }
        public DbSet<Cheffie.Models.Post> Post { get; set; }
        


    }
}
