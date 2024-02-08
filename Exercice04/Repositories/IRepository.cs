using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Exercice04.Models;

public interface IRepository<TEntity>
{
    bool Add(TEntity item);
    TEntity? Get(Expression<Func<TEntity, bool>> predicate);
    List<TEntity> GetAll();
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
    TEntity? GetById(int id);
    bool Update(TEntity item);
    bool Delete(int id);

}
