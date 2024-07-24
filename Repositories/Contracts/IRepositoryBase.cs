using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<Type>
    {
        IQueryable<Type> FindAll(bool trackChanges);

        Type? FindByCondition(Expression<Func<Type, bool>> expression, bool trackChanges);

        // Add new product
        void Create(Type entity);
    }
}