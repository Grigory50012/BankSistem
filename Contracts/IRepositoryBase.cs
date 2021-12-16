﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChenges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChenges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
