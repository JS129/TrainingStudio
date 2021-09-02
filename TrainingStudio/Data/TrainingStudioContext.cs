using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace TrainingStudio.Data
{
    public class TrainingStudioContext : DbContext
    {
        public TrainingStudioContext (DbContextOptions<TrainingStudioContext> options)
            : base(options)
        {
        }

        public DbSet<Classes> Classes { get; set; }

        public DbSet<Schedules> Schedules { get; set; }

        public DbSet<Query> Query { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
