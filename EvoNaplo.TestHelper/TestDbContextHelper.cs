using EvoNaplo.Common.Models;
using Microsoft.EntityFrameworkCore;
using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.UserDomain.Models;

namespace EvoNaplo.TestHelper
{
    public static class TestDbContextHelper
    {
        public static Repository<TEntity> CreateInMemoryDatabaseContext<TEntity>(string databaseName) where TEntity : class, IEntity
        {
            var options = new DbContextOptionsBuilder<Repository<TEntity>>()
                        .UseInMemoryDatabase(databaseName)
                        .Options;

            Repository<TEntity> testRepository = new Repository<TEntity>(options);
            return testRepository;
        }

        public static Repository<User> CreateDefaultUsers(this Repository<User> userRepository, int numberOfUsers, RoleType roleTypes)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                userRepository.Add(UserGenerator.CreateDefaultUser(roleTypes));
            }

            return userRepository;
        }

        public static Repository<TEntity> Build<TEntity>(this Repository<TEntity> genericRepository) where TEntity : class, IEntity
        {
            genericRepository.SaveChanges();
            return genericRepository;
        }
    }
}
