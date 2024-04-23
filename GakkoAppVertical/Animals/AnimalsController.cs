using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GakkoAppVertical.Animals;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService animalsService;
    
    public AnimalsController(IAnimalsService animalsService)
    {
        this.animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] [AllowedValues("name", "description", "category", "area")] string orderBy = "name")
    {
        try
        {
            var animals = animalsService.GetAnimals(orderBy);
            return Ok(animals);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        try
        {
            animalsService.AddAnimal(animal);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal(int idAnimal, [FromBody] AnimalProperties animalProperties)
    {
        try
        {
            animalsService.UpdateAnimal(idAnimal, animalProperties);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        try
        {
            animalsService.DeleteAnimal(idAnimal);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
