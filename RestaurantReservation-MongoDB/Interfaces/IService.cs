namespace RestaurantReservation_MongoDB.Interfaces;

public interface IService<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity entity);
    Task<List<TEntity>> GetAsync();
    Task<TEntity?> GetAsync(string id);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, TEntity updatedEntity);
}
