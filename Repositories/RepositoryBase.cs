using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<Type> : IRepositoryBase<Type>
    where Type : class, new()
    {
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<Type> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<Type>() : _context.Set<Type>().AsNoTracking();
        }
    }
}