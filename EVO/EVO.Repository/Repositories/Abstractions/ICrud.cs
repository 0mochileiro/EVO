using System.Linq.Expressions;

namespace EVO.Repository.Repositories.Abstractions;

public interface ICrud<T> where T : class
{
    T Create(T entity);

    IEnumerable<T> Create(IEnumerable<T> entities);

    T Update(T entity);

    IEnumerable<T> Update(IEnumerable<T> entities);

    bool Delete(T entity);

    bool Delete(IEnumerable<T> entities);

    T Find(Expression<Func<T, bool>> func);

    IEnumerable<T> FindAll(Expression<Func<T, bool>> func);

    IEnumerable<T> GetAll();
}
