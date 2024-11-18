using Microsoft.Extensions.Options;
using RestaurantReservation_MongoDB.Interfaces;
using RestaurantReservation_MongoDB.Models;
using RestaurantReservation_MongoDB.Repositories;

namespace RestaurantReservation_MongoDB.Services;
public class AnotherTestService(IOptions<MongoDbService> mongoDbSettings) : IService<AnotherTestModel>
{
    private readonly MongoDbRepository<AnotherTestModel> _collection = new(mongoDbSettings, "Test");

    public Task<List<AnotherTestModel>> GetAsync() => _collection.GetAsync();
    public Task<AnotherTestModel?> GetAsync(string id) => _collection.GetAsync(id);
    public Task CreateAsync(AnotherTestModel restaurant) => _collection.CreateAsync(restaurant);
    public Task UpdateAsync(string id, AnotherTestModel updatedRestaurant) => _collection.UpdateAsync(id, updatedRestaurant);
    public Task RemoveAsync(string id) => _collection.RemoveAsync(id);

}
