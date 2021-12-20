using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebAPI_1.Models;

namespace WebAPI_1.Data
{
    public class DepContext : DbContext
    {
        public DepContext (DbContextOptions<DepContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WebAPI_1.Models.Department> Departments { get; set; }
        public DbSet<WebAPI_1.Models.Employee> Employees { get; set; }
    }
}
