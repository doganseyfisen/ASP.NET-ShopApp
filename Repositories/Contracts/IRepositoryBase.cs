using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<Type>
    {
        IQueryable<Type> FindAll(bool trackChanges);        
    }
}