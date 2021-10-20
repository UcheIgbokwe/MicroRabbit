using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Transfer.Data.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>();
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=MRTransferDb;User Id=sa;Password=Ebubechi89;");

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}