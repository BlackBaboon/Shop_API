using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Azure.Core;
using System.Xml.Linq;

namespace BombKiev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentControl : Controller
    {
        private ICommentService _commentInterface;
        public CommentControl(ICommentService commentInterface)
        {
            _commentInterface = commentInterface;
        }

        /// <summary>
        /// Получение всех комментариев
        /// </summary>
        /// <returns>Список комментариев</returns>
        [HttpGet("comment/all")]
        public async Task<IActionResult> GetAll()
        {
            var comments_temp = await _commentInterface.GetAll();
            var comments = comments_temp.Adapt<List<GetComment>>();
            return Ok(comments);
        }

        /// <summary>
        /// Получение комментария пользователя на конкретный товар
        /// </summary>
        /// <returns>Комментарий</returns>
        [HttpGet("comment/{userid}_{goodid}")]
        public async Task<IActionResult> GetByIds(int userid,int goodid)
        {
            var comment_temp = await _commentInterface.GetByIds(userid, goodid);
            var comment = comment_temp.Adapt<GetComment>();
            return Ok(comment);
        }

        /// <summary>
        /// Получение комментария пользователя
        /// </summary>
        /// <returns>Список комментариев</returns>
        [HttpGet("comment/{userid}")]
        public async Task<IActionResult> GetByUserid(int userid)
        {
            var comment_temp = await _commentInterface.GetByUserid(userid);
            var comment = comment_temp.Adapt<List<GetComment>>();
            return Ok(comment);
        }

        /// <summary>
        /// Получение комментариев на товар
        /// </summary>
        /// <returns>Список комментариев</returns>
        [HttpGet("comment/{goodid}")]
        public async Task<IActionResult> GetByGoodid(int goodid)
        {
            var comment_temp = await _commentInterface.GetByGoodid(goodid);
            var comment = comment_temp.Adapt<List<GetComment>>();
            return Ok(comment);
        }

        /// <summary>
        /// Добавление комментария
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     POST
        ///     {
        ///         "userId": "2143153",
        ///         "goodId": "2143252",
        ///         "rate": "5",
        ///         "comment_": "этот прицел имба"
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost("comment/add")]
        public async Task<IActionResult> Add(CreateComment request)
        {
            var comment = request.Adapt<Comment>();
            await _commentInterface.Create(comment);
            return Ok();
        }


        /// <summary>
        /// Изменение комментария
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     PUT
        ///     {
        ///         "userId": "564536",
        ///         "goodId": "123426",
        ///         "rate": "4",
        ///         "comment_": "Фишки работают"
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPut("comment/update")]
        public async Task<IActionResult> Update(CreateComment request)
        {
            var comment = request.Adapt<Comment>();
            await _commentInterface.Update(comment);
            return Ok();
        }

        /// <summary>
        /// Удаление комментария
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
        [HttpDelete("comment/delete")]
        public async Task<IActionResult> Delete(int userid, int goodid)
        {
            await _commentInterface.Delete(userid,goodid);
            return Ok();
        }
    }
}
