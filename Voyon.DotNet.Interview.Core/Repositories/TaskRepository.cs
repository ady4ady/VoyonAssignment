using Voyon.DotNet.Interview.Core.Database;
using Voyon.DotNet.Interview.Core.Models;

namespace Voyon.DotNet.Interview.Core.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
