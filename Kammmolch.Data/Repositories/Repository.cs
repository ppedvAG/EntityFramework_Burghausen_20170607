using Kammmolch.Core.Models;
using Kammmolch.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kammmolch.Data.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> Entries { get; }

        public Repository(TContext context)
        {
            Context = context;
            Entries = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Entries.Find(id);
        }
        public Task<TEntity> GetAsync(int id)
        {
            return Entries.FindAsync(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Entries.ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entries.Where(predicate).ToList();
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Entries.FirstOrDefault(predicate);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Entries.SingleOrDefault(predicate);
        }
        public void Add(TEntity entity)
        {
            Entries.Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entries.AddRange(entities);
        }
        public void Remove(TEntity entity)
        {
            Entries.Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entries.RemoveRange(entities);
        }
    }
}
