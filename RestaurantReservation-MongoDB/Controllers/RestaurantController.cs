using Microsoft.AspNetCore.Mvc;
using RestaurantReservation_MongoDB.Interfaces;
using RestaurantReservation_MongoDB.Models;

namespace RestaurantReservation_MongoDB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController(IService<Restaurant> restaurantService) : ControllerBase
{
    private readonly IService<Restaurant> _restaurantService = restaurantService;

    [HttpGet("get")]
    public async Task<List<Restaurant>> Get()
    {
        return await _restaurantService.GetAsync();
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Restaurant>> Get(string id)
    {
        var book = await _restaurantService.GetAsync(id);

        if (book is null) return NotFound();

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Restaurant newRestaurant)
    {
        await _restaurantService.CreateAsync(newRestaurant);

        return CreatedAtAction(nameof(Get), new { id = newRestaurant.Id }, newRestaurant);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Restaurant updatedRestaurant)
    {
        var book = await _restaurantService.GetAsync(id);

        if (book is null) return NotFound();

        updatedRestaurant.Id = book.Id;

        await _restaurantService.UpdateAsync(id, updatedRestaurant);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _restaurantService.GetAsync(id);

        if (book is null) return NotFound();

        await _restaurantService.RemoveAsync(id);

        return NoContent();
    }


}
