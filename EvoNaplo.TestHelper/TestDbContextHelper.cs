using Microsoft.EntityFrameworkCore;
using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models.Entities;
using System.Collections.Generic;
using System;

namespace EvoNaplo.TestHelper
{
    public static class TestDbContextHelper
    {
        private static EvoNaploContext _evoNaploContext;
        private static IDictionary<Type, IRepository<IEntity>> _repositoryDictionary;

        public static EvoNaploContext CreateInMemoryContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<EvoNaploContext>()
                        .UseInMemoryDatabase(databaseName)
                        .Options;

            _evoNaploContext = new(options);
            return _evoNaploContext;
        }

        public static IRepository<TEntity> CreateRepository<TEntity>(this EvoNaploContext evoNaploContext) where TEntity : class, IEntity
        {
            IRepository<TEntity> testRepository = new Repository<TEntity>(evoNaploContext);
            //TODO: Add repo to dictonary
            return testRepository;
        }

        public static IRepository<User> CreateDefaultUsers(this IRepository<User> userRepository, int numberOfUsers, RoleType roleTypes)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                userRepository.Add(UserGenerator.CreateDefaultUser(roleTypes));
            }
            userRepository.SaveChangesAsync();

            return userRepository;
        }

        public static EvoNaploContext Build<TEntity>(this IRepository<TEntity> genericRepository) where TEntity : class, IEntity
        {
            return _evoNaploContext;
        }

        public static IRepository<TEntity> InjectRepository<TEntity>() where TEntity : class, IEntity
        {
            //TODO: return with correct repo from dictonary
            return new Repository<TEntity>(_evoNaploContext);
        }
    }
}
