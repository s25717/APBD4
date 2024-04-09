using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private static List<Animal> _animals = new List<Animal>();
    private static int _nextAnimalId = 1;

    [HttpGet]
    public IActionResult GetAllAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        animal.Id = _nextAnimalId++;
        _animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var existingAnimal = _animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null)
            return NotFound();

        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;

        return Ok(existingAnimal);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();

        _animals.Remove(animal);
        return NoContent();
    }
}