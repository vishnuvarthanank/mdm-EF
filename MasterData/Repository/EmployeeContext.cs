using MasterData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MasterData.Repository
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("employeeContext")
        {

        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}