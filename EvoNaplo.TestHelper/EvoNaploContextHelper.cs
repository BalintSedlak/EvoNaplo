using EvoNaplo.Common.Models;
using Microsoft.EntityFrameworkCore;
using EvoNaplo.Common.DataAccessLayer;
using System.Linq;

namespace EvoNaplo.TestHelper
{
    public static class EvoNaploContextHelper
    {
        public static EvoNaploContext CreateInMemoryDatabaseContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<EvoNaploContext>()
                        .UseInMemoryDatabase(databaseName)
                        .Options;

            EvoNaploContext evoNaploContext = new EvoNaploContext(options);
            return evoNaploContext;
        }

        public static EvoNaploContext CreateDefaultUsers(this EvoNaploContext evoNaploContext, int numberOfUsers, RoleType roleTypes)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                evoNaploContext.Users.Add(UserHelper.CreateDefaultUser(roleTypes));
            }

            return evoNaploContext;
        }
    }
}
