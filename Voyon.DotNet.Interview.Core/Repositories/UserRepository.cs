using Voyon.DotNet.Interview.Core.Database;
using Voyon.DotNet.Interview.Core.Models;

namespace Voyon.DotNet.Interview.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
