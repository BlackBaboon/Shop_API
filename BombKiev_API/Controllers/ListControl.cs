using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BombKiev_API.Controllers
{
    public class ListControl : Controller
    {
        MyDbContext db = new MyDbContext();
        private readonly ILogger<ListControl>? _logger;

        public ListControl(ILogger<ListControl> logger)
        {
            _logger = logger;
        }

        [HttpGet("WatchList")]
        public IActionResult WatchList([Required] int UserId)
        {
            return Ok(db.GoodsLists.Where(p => p.UserId == UserId).Select(p => p).ToList());
        }

        [HttpPost("AddCartGood")]
        public IActionResult AddGood([Required] int UserId, [Required] int GoodId, int Amount=1)
        {
            try
            {
                if (Amount <= 0)
                    throw new Exception();
                GoodsList Good = new GoodsList();
                Good.UserId= UserId;
                Good.GoodId = GoodId;
                Good.Amount = Amount;
                db.Add(Good);
                db.SaveChanges();
                return Ok("Добавлено в корзину");
            }
            catch (Exception ex) { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPut("ChangeAmount")]
        public IActionResult ChangeAmount([Required] int UserId, [Required] int GoodId, [Required] int ChangeAmount)
        {
            try
            {
                GoodsList? LstEx = db.GoodsLists.Where(p => p.UserId == UserId && p.GoodId == GoodId).FirstOrDefault();
                if (LstEx == null)
                    throw new Exception();
                LstEx.Amount += ChangeAmount;
                if (LstEx.Amount <= 0)
                {
                    LstEx.Amount -= ChangeAmount;
                    db.Remove(LstEx);
                }
                else
                {
                    db.Update(LstEx);
                }
                db.SaveChanges();
                return Ok("Количество изменено успешно");
            }
            catch (Exception ex) { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpDelete("DeleteCartGood")]
        public IActionResult DeleteGood([Required] int UserId, [Required] int GoodId)
        {
            try
            {
                db.GoodsLists.Remove(db.GoodsLists.Where(p => p.UserId == UserId && p.GoodId == GoodId).FirstOrDefault());
                db.SaveChanges();
                return Ok("Удаление произошло успешно");
            }
            catch { return BadRequest("Ошибка при удалении"); }
        }
    }
}
