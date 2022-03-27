using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.TestHelper;
using NUnit.Framework;

namespace EvoNaplo.ApplicationCore.Domains.Comments.IntegrationTest
{
    public class CommentsFacadeTest
    {

        private ICommentFacade _commentFacade;
        private EvoNaploContext _evoNaploContext;

        public void SetUp(string databaseName)
        {

            //Setup database
            _evoNaploContext = TestDbContextHelper
                .CreateInMemoryContext(databaseName)
                .CreateRepository<CommentEntity>()
                .Build();

        }
        [Test]
        public void PassBecauseNoneOfTheFunctionsAreImplemented()
        {
            Assert.Pass();
        }



    }
}