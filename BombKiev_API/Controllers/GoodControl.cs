using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DataAccess;
using BusinessLogic;


namespace BombKiev_API.Controllers
{
    public class GoodControl : Controller
    {
        private readonly ILogger<GoodControl>? _logger;
        GoodsDB db = new GoodsDB();

        public GoodControl(ILogger<GoodControl> logger)
        {
            _logger = logger;
        }

        [HttpGet("EnableGoods")]
        public IActionResult EnableGood()
        {
            return Ok(db.Enable());
        }

        [HttpGet("SearchByTitle")]
        public IActionResult EnableGood([Required] string Title)
        {
            return Ok(db.Enable(Title));
        }

        [HttpPost("AddGood")]
        public IActionResult GoodAdd([Required] int Id, [Required] string Title, [Required] decimal Price,
            [Required] int StartAmount, string Desc="")
        {
            try
            {
                db.Add(Id, Title, Price, StartAmount, Desc);
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
                db.Change(Id, Title, Price, AmountChange, Desc);
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }
    }
}
