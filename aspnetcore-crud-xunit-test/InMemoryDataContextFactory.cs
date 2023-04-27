using aspnetcore_crud.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace aspnetcore_crud_xunit_test
{
    internal class InMemoryDataContextFactory
    {
        public DataContext GetApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                       .UseInMemoryDatabase(databaseName: "AspDotNetCoreAngularCrud")
                       .Options;
            var dbContext = new DataContext(options);

            return dbContext;
        }
    }
}
