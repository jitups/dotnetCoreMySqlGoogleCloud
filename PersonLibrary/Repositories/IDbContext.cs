using Microsoft.EntityFrameworkCore;
using PersonLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary.Repositories
{
    public interface IDbContext:IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
