using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DataAccess;
using DataAccess.Model;
using Domain.Model;
using BusinessLogic;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace BombKiev_API.Controllers
{
    public class GoodControl : Controller
    {
        private IGoodService _goodInterface;
        public GoodControl(IGoodService goodInterface)
        {
            _goodInterface = goodInterface;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _goodInterface.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _goodInterface.GetById(id));
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Good good)
        {
            await _goodInterface.Create(good);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Good good)
        {
            await _goodInterface.Update(good);
            return Ok();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _goodInterface.Delete(id);
            return Ok();
        }

    }
}
