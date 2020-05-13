﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Voyon.DotNet.Interview.Core.Repositories
{
    public interface IGenericRepository<T>
    {
        ICollection<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        T Get(Guid id);
        bool Create(T model);
        bool Update(Guid id, T Model);
        bool Delete(Guid id, T model);
    }
}
