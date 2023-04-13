using Domain.Interfaces;
using Domain.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BombKiev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipControl : Controller
    {
        private IShipService _shipInterface;
        public ShipControl(IShipService shipInterface)
        {
            _shipInterface = shipInterface;
        }

        /// <summary>
        /// Получение заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        [HttpGet("ship/all")]
        public async Task<IActionResult> GetAll()
        {
            var ships_temp = await _shipInterface.GetAll();
            var ships = ships_temp.Adapt<List<GetShip>>();
            return Ok(ships);
        }

        /// <summary>
        /// Получение заказа по коду
        /// </summary>
        /// <returns>Заказ</returns>
        [HttpGet("ship/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ships_temp = await _shipInterface.GetAll();
            var ships = ships_temp.Adapt<List<GetShip>>();
            return Ok(ships);
        }

        /// <summary>
        /// Добавление заказа
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     POST
        ///     {
        ///         "id": 125325,
        ///         "userId": 763457,
        ///         "goodId": 657468,
        ///         "amount": 3,
        ///         "shipDate": "2023-04-13",
        ///         "status": "в обработке",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost("ship/add")]
        public async Task<IActionResult> Add(CreateShip request)
        {
            var ship = request.Adapt<Ship>();
            await _shipInterface.Create(ship);
            return Ok();
        }

        /// <summary>
        /// Изменение заказа
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     PUT
        ///     {
        ///         "id": 125325,
        ///         "userId": 763457,
        ///         "goodId": 657468,
        ///         "amount": 3,
        ///         "shipDate": "2023-04-13",
        ///         "status": "в обработке",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPut("ship/update")]
        public async Task<IActionResult> Update(CreateShip request)
        {
            var ship = request.Adapt<Ship>();
            await _shipInterface.Update(ship);
            return Ok();
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     DELETE
        ///     {
        ///         "id": 125325,
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("ship/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shipInterface.Delete(id);
            return Ok();
        }
    }
}
