using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BombKiev_API.Controllers
{
    public class ShipControll : Controller
    {
        MyDbContext db = new MyDbContext();
        private readonly ILogger<ShipControll>? _logger;

        public ShipControll(ILogger<ShipControll> logger)
        {
            _logger = logger;
        }

        
        [HttpPost("AddShip")]
        public IActionResult AddShip([Required] int UserId)
        {
            try
            {
                List<GoodsList> Goods = db.GoodsLists.Where(p=> p.UserId == UserId).Select(p=>p).ToList();
                int ShipId;
                if (db.Ships.Select(p => p.Id).Count() == 0)
                    ShipId = 1;
                else 
                    ShipId = db.Ships.Select(p => p.Id).Max() + 1;

                foreach (var Good in Goods)
                {
                    Ship ShipPos = new Ship();
                    ShipPos.Id = ShipId;
                    ShipPos.UserId = Good.UserId;
                    ShipPos.GoodId = Good.GoodId;
                    ShipPos.Amount = Good.Amount;
                    ShipPos.ShipDate = DateTime.Now;
                    ShipPos.Status = "In processing";
                    db.Ships.Add(ShipPos);
                }
                db.SaveChanges();
                return Ok("Заказ создан");
            }
            catch (Exception ex) { return BadRequest("Ошибка при добавлении") ; }
        }

        [HttpPut("ChangeStatus")]
        public IActionResult ChangeAmount([Required] int ShipId,  [Required] string Status)
        {
            try
            {
                if (!new List<string> { "In processing", "In deliver", "Delivered", "Cancelled" }.Contains(Status))
                    throw new Exception();

                var List = db.Ships.Where(p => p.Id == ShipId).Select(p=>p).ToList();
                foreach(var Ship in List)
                {
                    Ship.Status = Status;
                    db.Update(Ship);
                }
                db.SaveChanges();
                return Ok("Статус обновлён");
            }
            catch (Exception ex) { return BadRequest("Ошибка при добавлении"); }
        }
    }
}
