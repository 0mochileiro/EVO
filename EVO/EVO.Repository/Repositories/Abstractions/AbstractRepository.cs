using EVO.Repository.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EVO.Repository.Repositories.Abstractions;

public abstract class AbstractRepository<T> : IDisposable, ICrud<T> where T : class
{
    protected readonly Context context;

    public AbstractRepository(DbContextOptions<Context> dbContextOptions)
    {
        context = new Context(dbContextOptions);
    }

    public virtual T Create(T entity)
    {
        context.Add(entity);

        context.SaveChanges();

        return entity;
    }

    public virtual IEnumerable<T> Create(IEnumerable<T> entities)
    {
        context.AddRange(entities);

        context.SaveChanges();

        return entities;
    }

    public virtual T? Find(Expression<Func<T, bool>> func)
    {
        return context.Set<T>().FirstOrDefault(func);
    }

    public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> func)
    {
        return context.Set<T>().Where(func).ToList();
    }

    public virtual IEnumerable<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public virtual bool Any(Expression<Func<T, bool>> func)
    {
        return context.Set<T>().Any(func);
    }

    public virtual T Update(T entity)
    {
        context.Update(entity);

        context.SaveChanges();

        return entity;
    }

    public virtual IEnumerable<T> Update(IEnumerable<T> entities)
    {
        context.UpdateRange(entities);

        context.SaveChanges();

        return entities;
    }

    public bool Delete(T entity)
    {
        context.Remove(entity);

        return context.SaveChanges() > 0;
    }

    public bool Delete(IEnumerable<T> entities)
    {
        context.RemoveRange(entities);

        return context.SaveChanges() > 0;
    }

    public void RollbackPendingTransactions()
    {
        context.Database.ExecuteSqlRaw("if @@trancount > 0 rollback;");
    }

    public void Dispose()
    {
        context?.Dispose();
    }
}