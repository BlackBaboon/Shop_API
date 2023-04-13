using Azure.Core;
using Domain.Interfaces;
using Domain.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BombKiev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControl : Controller
    {
        private IUserService _userInterface;
        public UserControl(IUserService userInterface)
        {
            _userInterface = userInterface;
        }

        /// <summary>
        /// Получение пользователей
        /// </summary>
        /// <returns>Список Список пользователей</returns>
        [HttpGet("user/all")]
        public async Task<IActionResult> GetAll()
        {
            var users_temp = await _userInterface.GetAll();
            List<GetUser> users = users_temp.Adapt<List<GetUser>>();
            return Ok(users);
        }

        /// <summary>
        /// Получение пользователя по коду
        /// </summary>
        /// <returns>Пользователь</returns>
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user_temp = await _userInterface.GetById(id);
            GetUser user = user_temp.Adapt<GetUser>();
            return Ok(user);
        }


        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     POST
        ///     {
        ///         "id": 543543,
        ///         "nickname": "Kuxorg",
        ///         "surname": "Калинов",
        ///         "name": "Георгий",
        ///         "email": "ranobe@gmail.com",
        ///         "password": "1488zxcsalo",
        ///         "phonenumber": "13372281488",
        ///         "authed": true,
        ///         "isAdmin": true,
        ///         "isDelete": true,
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost("user/add")]
        public async Task<IActionResult> Add(CreateUser request)
        {
            var user = request.Adapt<User>();
            await _userInterface.Create(user);
            return Ok();
        }



        /// <summary>
        /// Изменение пользователя
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     POST
        ///     {
        ///         "id": 543543,
        ///         "nickname": "Kuxorg",
        ///         "surname": "Калинов",
        ///         "name": "Георгий",
        ///         "email": "ranobe@gmail.com",
        ///         "password": "1488zxcsalo",
        ///         "phonenumber": "13372281488",
        ///         "authed": true,
        ///         "isAdmin": true,
        ///         "isDelete": true,
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPut("user/update")]
        public async Task<IActionResult> Update(CreateUser request)
        {
            var user = request.Adapt<User>();
            await _userInterface.Update(user);
            return Ok();
        }


        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     DELETE
        ///     {
        ///         "id": 543543,
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("user/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userInterface.Delete(id);
            return Ok();
        }
    }
}
