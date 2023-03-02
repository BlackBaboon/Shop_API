using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BombKiev_API.Controllers
{
    public class GoodControl : Controller
    {
        MyDbContext db = new MyDbContext();
        private readonly ILogger<GoodControl>? _logger;

        public GoodControl(ILogger<GoodControl> logger)
        {
            _logger = logger;
        }

        [HttpGet("EnableGoods")]
        public IActionResult EnableGood()
        {
            return Ok(db.Goods.Where(p => p.Amount > 0).Select(p => p).ToList());
        }

        [HttpGet("SearchByTitle")]
        public IActionResult EnableGood([Required] string Title)
        {
            return Ok(db.Goods.Where(p => p.Title.ToLower().Contains(Title.ToLower())).Select(p => p).ToList());
        }

        [HttpPost("AddGood")]
        public IActionResult GoodAdd([Required] int Id, [Required] string Title, [Required] decimal Price,
            [Required] int StartAmount, string Desc="")
        {
            try
            {
                Good NewGood = new Good();
                NewGood.Id = Id;
                NewGood.Title = Title;
                NewGood.Price = Price;
                NewGood.Amount = StartAmount;
                NewGood.Descryption = Desc;
                db.Goods.Add(NewGood);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPut("EditGood")]
        public IActionResult GoodChange([Required] int Id, string Title="", decimal Price=0,
            int AmountChange=0, string Desc="")
        {
            try
            {
                Good? NewGood = db.Goods.Where(p => p.Id == Id).Select(p => p).FirstOrDefault();
                NewGood.Title = Title == ""? NewGood.Title : Title;
                NewGood.Price = Price == 0 ? NewGood.Price : Price;
                NewGood.Amount += AmountChange;
                NewGood.Descryption = Desc == "" ? NewGood.Descryption : Desc;
                db.Goods.Update(NewGood);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }
    }
}
