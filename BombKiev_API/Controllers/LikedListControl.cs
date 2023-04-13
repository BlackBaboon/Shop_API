using Azure.Core;
using Domain.Interfaces;
using Domain.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BombKiev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedListControl : Controller
    {
        private ILikedListService _likedListInterface;
        public LikedListControl(ILikedListService likedListInterface)
        {
            _likedListInterface = likedListInterface;
        }

        /// <summary>
        /// Получение всех списков желаемого
        /// </summary>
        /// <returns>Список желаемого</returns>
        [HttpGet("likedList/all")]
        public async Task<IActionResult> GetAll()
        {
            var likedlist_temp = await _likedListInterface.GetAll();
            var likedlist = likedlist_temp.Adapt<List<GetLikedList>>();
            return Ok(likedlist);
        }

        /// <summary>
        /// Получение списка желаемого конкретного пользователя и товара
        /// </summary>
        /// <returns>КорСписок желаемогозина</returns>
        [HttpGet("likedList/{userid}_{goodid}")]
        public async Task<IActionResult> GetByIds(int userid, int goodid)
        {
            var likedlist_temp = await _likedListInterface.GetByIds(userid, goodid);
            var likedlist = likedlist_temp.Adapt<GetLikedList>();
            return Ok(likedlist);
        }

        /// <summary>
        /// Получение всех списков желаемого конкретного пользователя
        /// </summary>
        /// <returns>Список списков желаемого</returns>
        [HttpGet("likedList/{userid}")]
        public async Task<IActionResult> GetByUserid(int userid)
        {
            var likedlist_temp = await _likedListInterface.GetByUserid(userid);
            var likedlist = likedlist_temp.Adapt<List<GetLikedList>>();
            return Ok(likedlist);
        }

        /// <summary>
        /// Получение всех списков желаемого с конкретным товаром
        /// </summary>
        /// <returns>Список списков желаемого</returns>
        [HttpGet("likedList/{goodid}")]
        public async Task<IActionResult> GetByGoodid(int goodid)
        {
            var likedlist_temp = await _likedListInterface.GetByGoodid(goodid);
            var likedlist = likedlist_temp.Adapt<List<GetLikedList>>();
            return Ok(likedlist);
        }

        /// <summary>
        /// Добавление желаемого
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     POST
        ///     {
        ///         "userId": "9679579",
        ///         "goodId": "7659876",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost("likedList/add")]
        public async Task<IActionResult> Add(CreateUser request)
        {
            var likedList = request.Adapt<LikedList>();
            await _likedListInterface.Create(likedList);
            return Ok();
        }

        /// <summary>
        /// Изменение желаемого
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     PUT
        ///     {
        ///         "userId": "4325436",
        ///         "goodId": "1346467",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPut("likedList/update")]
        public async Task<IActionResult> Update(CreateUser request)
        {
            var likedList = request.Adapt<LikedList>();
            await _likedListInterface.Update(likedList);
            return Ok();
        }

        /// <summary>
        /// Удаление желаемого
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     DELETE
        ///     {
        ///         "userId": "4325436",
        ///         "goodId": "1346467",
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("likedList/delete")]
        public async Task<IActionResult> Delete(int userid, int goodid)
        {
            await _likedListInterface.Delete(userid, goodid);
            return Ok();
        }
    }
}
