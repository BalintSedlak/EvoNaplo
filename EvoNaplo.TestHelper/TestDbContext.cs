using EvoNaplo.UserDomain.Models;

namespace EvoNaplo.Common.DataAccessLayer
{
    public class TestDbContext 
    {
        public IRepository<User> UsersRepositry { get; set; }
    }
}
