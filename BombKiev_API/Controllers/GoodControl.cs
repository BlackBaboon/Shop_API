using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Domain.Interfaces;
using Mapster;
using Azure.Core;

namespace BombKiev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodControl : Controller
    {
        private IGoodService _goodInterface;
        public GoodControl(IGoodService goodInterface)
        {
            _goodInterface = goodInterface;
        }

        /// <summary>
        /// Получение всех товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        [HttpGet("good/all")]
        public async Task<IActionResult> GetAll()
        {
            var goods_temp = await _goodInterface.GetAll();
            var goods = goods_temp.Adapt<List<GetGood>>();
            return Ok(goods);
        }

        /// <summary>
        /// Получение товара по коду
        /// </summary>
        /// <returns>Товар</returns>
        [HttpGet("good/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var good_temp = await _goodInterface.GetById(id);
            var good = good_temp.Adapt<GetGood>();
            return Ok(good);  
        }

        /// <summary>
        /// Добавление товара
        /// </summary> 
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     POST
        ///     {
        ///         "id": 123543,
        ///         "category": "лучшие видеокарты на рынке",
        ///         "title": "GTX 1050 TI MSI GAMING X",
        ///         "price": 24990, 
        ///         "amount": 10, 
        ///         "descryption": "Лучшая видеокарта на рынке",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost("good/add")]
        public async Task<IActionResult> Add(CreateGood request)
        {
            var good = request.Adapt<Good>(); 
            await _goodInterface.Create(good);
            return Ok();
        }


        /// <summary>
        /// Изменение товара
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     PUT
        ///     {
        ///         "id": 123543,
        ///         "title": "GTX 1050 TI MSI GAMING X",
        ///         "price": 24990, 
        ///         "amount": 1, 
        ///         "descryption": "Лучшая видеокарта на рынке",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPut("good/update")]
        public async Task<IActionResult> Update(CreateGood request)
        {
            var good = request.Adapt<Good>();
            await _goodInterface.Update(good);
            return Ok();
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     DELETE
        ///     {
        ///         "id": 4325436,
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("good/delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _goodInterface.Delete(id);
            return Ok();
        }

    }
}
