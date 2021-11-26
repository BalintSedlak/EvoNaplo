using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using Microsoft.EntityFrameworkCore;

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

        public static EvoNaploContext CreateDefaultUsers(this EvoNaploContext evoNaploContext, int numberOfUsers, User.RoleTypes roleTypes)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                evoNaploContext.Users.Add(UserHelper.CreateDefaultUser(roleTypes));
            }

            return evoNaploContext;
        }
    }
}
