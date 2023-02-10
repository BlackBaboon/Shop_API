using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BombKiev_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UkraineWeather : ControllerBase
    {
        private static List<string> Slava_RoZZii = new()
        {
        "Герань-2","Калибр","Базальт","Малахит","Царь-Бомба"
        };

        private readonly ILogger<UkraineWeather> _logger;

        public UkraineWeather(ILogger<UkraineWeather> logger)
        {
            _logger = logger;
        }

        [HttpGet("Поиск по индексу")]
        public IActionResult GetByIndex([Required] int index)
        {
            if (index < 0 || index >= Slava_RoZZii.Count)
                return BadRequest("Неверный индекс элемента");
            return Ok(Slava_RoZZii[index]);
        }

        [HttpGet("Поиск по имени")]
        public int GetByName([Required] string name)
        {
            return Slava_RoZZii.Where(p => p == name).Count();
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrat)
        {
            if(sortStrat == null)
            {
                return Ok(Slava_RoZZii);
            }
            else if(sortStrat == 1)
            {
                return Ok(Slava_RoZZii.OrderBy(p => p));
            }
            else if(sortStrat == -1)
            {
                return Ok(Slava_RoZZii.OrderByDescending(p=>p));
            }
            else
            {
                return BadRequest("Неправильно. Попробуй ещё раз");
            }
        }

        [HttpPost]
        public IActionResult Add([Required] string name)
        {
            Slava_RoZZii.Add(name);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([Required] int index)
        {
            if (index < 0 || index >= Slava_RoZZii.Count)
                return BadRequest("Неверный индекс элемента");
            Slava_RoZZii.RemoveAt(index);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([Required] int index, [Required] string name)
        {
            if(index < 0 || index >= Slava_RoZZii.Count)
                return BadRequest("Неверный индекс элемента");

            Slava_RoZZii[index] = name;
            return Ok();
        }
    }
}