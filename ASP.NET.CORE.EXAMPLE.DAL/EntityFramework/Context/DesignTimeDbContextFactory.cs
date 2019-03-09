using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.CORE.EXAMPLE.DAL.EntityFramework.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
           
            var builder = new DbContextOptionsBuilder<SchoolContext>();
            var connectionString = "Data Source=.;Initial Catalog=DotNetCoreDB;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
            return new SchoolContext(builder.Options);
        }
    }

}
