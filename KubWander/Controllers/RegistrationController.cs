using KubWander.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BCrypt;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KubWander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public RegistrationController(ApplicationDbContext context, UserManager<User> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/<RegistrationController>
        // возвращается список объектов
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/<RegistrationController>/5
        // возвращает один объект из списка
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegistrationController>
        // сохранение данных (регистрация полльзователя)
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                UserName = registerModel.Email,
                Name = registerModel.Name,
                Email = registerModel.Email,
                PasswordHash = registerModel.Password,
                Role = "user",
                Points = 0,
                RegisteredAt = DateTime.UtcNow
            };
            
            var finalRegister = await _userManager.CreateAsync(user, registerModel.Password);

            if (finalRegister.Succeeded) return Ok("Регистрация завершена!");

            foreach (var error in finalRegister.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return BadRequest(ModelState);

        }

        // PUT api/<RegistrationController>/5
        // обновление данных записи (по id, value)
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistrationController>/5
        // Удаление записи
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
