using Microsoft.AspNetCore.Mvc;
using RestaurantReservation_MongoDB.Interfaces;
using RestaurantReservation_MongoDB.Models;

namespace RestaurantReservation_MongoDB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnotherTestController(IService<AnotherTestModel> anotherTestService) : ControllerBase
{
    private readonly IService<AnotherTestModel> _service = anotherTestService;

    [HttpGet("get")]
    public async Task<List<AnotherTestModel>> Get()
    {
        return await _service.GetAsync();
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<AnotherTestModel>> Get(string id)
    {
        var book = await _service.GetAsync(id);

        if (book is null) return NotFound();

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AnotherTestModel newRestaurant)
    {
        await _service.CreateAsync(newRestaurant);

        return CreatedAtAction(nameof(Get), new { id = newRestaurant.Id }, newRestaurant);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, AnotherTestModel updatedRestaurant)
    {
        var book = await _service.GetAsync(id);

        if (book is null) return NotFound();

        updatedRestaurant.Id = book.Id;

        await _service.UpdateAsync(id, updatedRestaurant);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _service.GetAsync(id);

        if (book is null) return NotFound();

        await _service.RemoveAsync(id);

        return NoContent();
    }


}
