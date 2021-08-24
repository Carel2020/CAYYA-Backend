using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CAYYA_Backend.Models;

namespace CAYYA_Backend.Data
{
    public class CAYYA_BackendContext : DbContext
    {
        public CAYYA_BackendContext (DbContextOptions<CAYYA_BackendContext> options)
            : base(options)
        {
        }

        public DbSet<CAYYA_Backend.Models.Role> Role { get; set; }

        public DbSet<CAYYA_Backend.Models.Category> Category { get; set; }
    }
}
