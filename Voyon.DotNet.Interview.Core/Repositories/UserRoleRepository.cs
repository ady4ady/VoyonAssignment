using Voyon.DotNet.Interview.Core.Database;
using Voyon.DotNet.Interview.Core.Models;

namespace Voyon.DotNet.Interview.Core.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
