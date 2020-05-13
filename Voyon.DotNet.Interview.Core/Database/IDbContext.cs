using System.Collections.Generic;

namespace Voyon.DotNet.Interview.Core.Database
{
    public interface IDbContext
    {
        ICollection<T> GetDataset<T>();
        bool Save();
    }
}
