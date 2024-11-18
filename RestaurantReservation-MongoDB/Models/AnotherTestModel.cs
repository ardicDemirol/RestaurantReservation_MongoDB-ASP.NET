using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RestaurantReservation_MongoDB.Interfaces;

namespace RestaurantReservation_MongoDB.Models;
public class AnotherTestModel : IEntity
{
    [BsonRequired]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Cuisine { get; set; }
    public string? Borough { get; set; }
}
