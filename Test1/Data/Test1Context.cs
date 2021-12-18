using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test1.Models;

namespace Test1.Data
{
    public class Test1Context : DbContext
    {
        public Test1Context (DbContextOptions<Test1Context> options)
            : base(options)
        {
        }

        public DbSet<Test1.Models.Movie> Movie { get; set; }
    }
}
