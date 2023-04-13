using Domain.Interfaces;
using Domain.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BombKiev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsLstControl : Controller
    {
        private IGoodsListService _goodsListInterface;
        public GoodsLstControl(IGoodsListService goodsListInterface)
        {
            _goodsListInterface = goodsListInterface;
        }
        /// <summary>
        /// Получение всех корзин
        /// </summary>
        /// <returns>Список корзин</returns>
        [HttpGet("goodsList/all")]
        public async Task<IActionResult> GetAll()
        {
            var goodslist_temp = await _goodsListInterface.GetAll();
            var goodslist = goodslist_temp.Adapt<List<GetGoodsList>>();
            return Ok(goodslist);
        }


        /// <summary>
        /// Получение корзины пользователя с товаром
        /// </summary>
        /// <returns>Корзина</returns>
        [HttpGet("goodsList/{userid}_{goodid}")]
        public async Task<IActionResult> GetByIds(int userid, int goodid)
        {
            var goodslist_temp = await _goodsListInterface.GetAll();
            var goodslist = goodslist_temp.Adapt<GetGoodsList>();
            return Ok(goodslist);
        }

        /// <summary>
        /// Получение всей корзины пользователя
        /// </summary>
        /// <returns>Список корзин</returns>
        [HttpGet("goodsList/{userid}")]
        public async Task<IActionResult> GetByUserid(int userid)
        {
            var goodslist_temp = await _goodsListInterface.GetByUserid(userid);
            var goodslist = goodslist_temp.Adapt<List<GetGoodsList>>();
            return Ok(goodslist);
        }

        /// <summary>
        /// Получение корзин по товару
        /// </summary>
        /// <returns>Список корзин</returns>
        [HttpGet("goodsList/{goodid}")]
        public async Task<IActionResult> GetByGoodid(int goodid)
        {
            var goodslist_temp = await _goodsListInterface.GetByGoodid(goodid);
            var goodslist = goodslist_temp.Adapt<List<GetGoodsList>>();
            return Ok(goodslist);
        }

        /// <summary>
        /// Добавление корзины
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     POST
        ///     {
        ///         "userId": "9679579",
        ///         "goodId": "7659876",
        ///         "amount": "5",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost("goodsList/add")]
        public async Task<IActionResult> Add(CreateGoodsList request)
        {
            var goodsList = request.Adapt<GoodsList>();
            await _goodsListInterface.Create(goodsList);
            return Ok();
        }


        /// <summary>
        /// Обновление корзины
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     PUT
        ///     {
        ///         "userId": "9679579",
        ///         "goodId": "7659876",
        ///         "amount": "7",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPut("goodsList/update")]
        public async Task<IActionResult> Update(CreateGoodsList request)
        {
            var goodsList = request.Adapt<GoodsList>();
            await _goodsListInterface.Update(goodsList);
            return Ok();
        }

        /// <summary>
        /// Удаление корзины
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     DELETE
        ///     {
        ///         "userId": "564536",
        ///         "goodId": "123426",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("goodsList/delete")]
        public async Task<IActionResult> Delete(int userid, int goodid)
        {
            await _goodsListInterface.Delete(userid, goodid);
            return Ok();
        }
    }
}
