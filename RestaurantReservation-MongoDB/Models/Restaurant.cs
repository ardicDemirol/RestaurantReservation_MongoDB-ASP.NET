using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using RestaurantReservation_MongoDB.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation_MongoDB.Models;

[Collection("restaurants")]
public class Restaurant : IEntity
{
    [BsonRequired, BsonRepresentation(BsonType.ObjectId)]
    [Required]
    public string Id { get; set; }

    [BsonElement("restaurant_name")]
    public string? Name { get; set; }

    [BsonElement("cuisine_name")]
    public string? Cuisine { get; set; }

    [BsonElement("borough_name")]
    public string? Borough { get; set; }
}
