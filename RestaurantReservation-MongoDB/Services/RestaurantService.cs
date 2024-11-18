using Microsoft.Extensions.Options;
using RestaurantReservation_MongoDB.Interfaces;
using RestaurantReservation_MongoDB.Models;
using RestaurantReservation_MongoDB.Repositories;

namespace RestaurantReservation_MongoDB.Services;
public class RestaurantService(IOptions<MongoDbService> mongoDbSettings) : IService<Restaurant>
{
    private readonly MongoDbRepository<Restaurant> _collection = new(mongoDbSettings, "RRCollection");

    public Task<List<Restaurant>> GetAsync() => _collection.GetAsync();
    public Task<Restaurant?> GetAsync(string id) => _collection.GetAsync(id);
    public Task CreateAsync(Restaurant restaurant) => _collection.CreateAsync(restaurant);
    public Task UpdateAsync(string id, Restaurant updatedRestaurant) => _collection.UpdateAsync(id, updatedRestaurant);
    public Task RemoveAsync(string id) => _collection.RemoveAsync(id);

}
