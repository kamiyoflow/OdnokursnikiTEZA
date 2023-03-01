using TEZAProject.Domain;

namespace TEZAProject.Dal.Interfaces
{
     public interface IUserProfileRepository
     {
          Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;
          Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;
          void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
          Task SaveChangesAsync();
          void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
          Task Delete<TEntity>(int id) where TEntity : BaseEntity;

     }
}
