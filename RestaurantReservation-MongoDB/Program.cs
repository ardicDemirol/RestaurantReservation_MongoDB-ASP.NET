using RestaurantReservation_MongoDB.Interfaces;
using RestaurantReservation_MongoDB.Models;
using RestaurantReservation_MongoDB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbService>(
    builder.Configuration.GetSection("RRSystemDatabase"));

builder.Services.AddSingleton<IService<Restaurant>, RestaurantService>();
builder.Services.AddSingleton<IService<AnotherTestModel>, AnotherTestService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
