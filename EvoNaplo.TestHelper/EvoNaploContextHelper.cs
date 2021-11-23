using EvoNaplo.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.TestHelper
{
    public static class EvoNaploContextHelper
    {
        public static EvoNaploContext CreateInMemoryDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<EvoNaploContext>()
                        .UseInMemoryDatabase(databaseName: "Test")
                        .Options;

            EvoNaploContext evoNaploContext = new EvoNaploContext(options);
            return evoNaploContext;
        }
    }
}
