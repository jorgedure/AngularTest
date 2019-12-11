using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace AplicationDataContext
{
    public class DataContext : DbContext, IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext(){
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

        }
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true;");
            var context = new DataContext(optionsBuilder.Options);
            return context;
        }
        public virtual DbSet<TodoList> TodoList { get; set; }
    }
}
