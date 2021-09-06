using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ComputerContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=192.168.0.144; Port=5432; Data Id=postgres; Persist Security Info=True; Username=olist; Password=olist123");
        }
    }
}
