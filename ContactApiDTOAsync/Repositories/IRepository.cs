using System.Linq.Expressions;

namespace ContactApiDTO.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // CREATE
        //bool Add(TEntity entity); // bool => si ça s'est bien passé
        //int Add(TEntity entity); // int => id de l'entité
        Task<TEntity?> Add(TEntity entity); // TEntity => on retourne l'entité qui vient d'être ajoutée

        // READ
        Task<TEntity?> Get(int id); // uniquement l'id
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate); // avec un délégué/fonction pour filtrer
        Task<IEnumerable<TEntity>> GetAll(); // toutes les entités
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate); // avec un délégué/fonction pour filtrer

        // UPDATE
        //bool Update(TEntity contact); // bool => si ça s'est bien passé
        Task<TEntity?> Update(TEntity entity); // TEntity => on retourne l'entité qui vient d'être modifiée

        // DELETE
        Task<bool> Delete(int id);

    }
}
