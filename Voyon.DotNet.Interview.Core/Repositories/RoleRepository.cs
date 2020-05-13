using Voyon.DotNet.Interview.Core.Database;
using Voyon.DotNet.Interview.Core.Models;

namespace Voyon.DotNet.Interview.Core.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
