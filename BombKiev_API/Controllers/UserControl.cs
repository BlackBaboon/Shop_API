using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BombKiev_API.Controllers
{
    public class UserControl : Controller
    {
        MyDbContext db = new MyDbContext();
        private readonly ILogger<UserControl>? _logger;

        public UserControl(ILogger<UserControl> logger)
        {
            _logger = logger;
        }

        [HttpGet("Auth")]
        public IActionResult UserCheck([Required] string Email,
            [Required] string Password)
        {
            if(db.Users.Where(p=> p.Password == Password && p.Email == Email).Count() == 1) 
                return Ok("Успешный вход");
            else
                return BadRequest("Неверный логин или пароль");
        }

        [HttpPost("Add")]
        public IActionResult UserAdd([Required] int Id, string Nickname, string Name,
            string Surname, string Email, string Password,
            string Phonenumber)
        {
            try
            {
                User NewUser = new User();
                NewUser.Id = Id;
                NewUser.Nickname = Nickname;
                NewUser.Surname = Surname;
                NewUser.Email = Email;
                NewUser.Phonenumber = Phonenumber;
                NewUser.Password = Password;
                NewUser.IsDelete = false;
                NewUser.IsAdmin = false;
                NewUser.Name = Name;
                db.Users.Add(NewUser);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPut("Edit")]
        public IActionResult UserAdd([Required] int Id, string Nickname = "", string Name = "",
           string Surname = "", string Email = "", string Password = "",
           string Phonenumber = "", int Delete = 0, int Admin = 0)
        {
            try
            {
                User? NewUser = db.Users.Where(p => p.Id == Id).Select(p => p).FirstOrDefault();
                NewUser.Nickname = Nickname == "" ? NewUser.Nickname : Nickname;
                NewUser.Surname = Surname == "" ? NewUser.Surname : Surname;
                NewUser.Email = Email == "" ? NewUser.Email : Email;
                NewUser.Phonenumber = Phonenumber == "" ? NewUser.Phonenumber : Phonenumber;
                NewUser.Password = Password == "" ? NewUser.Password : Password;
                NewUser.IsDelete = Convert.ToBoolean(Delete);
                NewUser.IsAdmin = Convert.ToBoolean(Admin);
                NewUser.Name = Name == "" ? NewUser.Name : Name;
                db.Users.Update(NewUser);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }
    }
}
