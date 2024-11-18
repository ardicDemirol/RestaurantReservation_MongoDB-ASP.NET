using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RestaurantReservation_MongoDB.Interfaces;
using RestaurantReservation_MongoDB.Services;

namespace RestaurantReservation_MongoDB.Repositories;

public class MongoDbRepository<TEntity> where TEntity : class, IEntity
{
    private readonly IMongoCollection<TEntity> _collection;

    public MongoDbRepository(IOptions<MongoDbService> mongoDbSettings, string collectionName)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<TEntity>(collectionName);
    }

    public async Task<List<TEntity>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<TEntity?> GetAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TEntity entity) =>
        await _collection.InsertOneAsync(entity);

    public async Task UpdateAsync(string id, TEntity updatedEntity) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, updatedEntity);

    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}

