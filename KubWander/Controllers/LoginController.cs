using Microsoft.AspNetCore.Mvc;
using KubWander.Models;
using Microsoft.AspNetCore.Identity;
using BCrypt;

namespace KubWander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if(user == null) return Unauthorized(new {Error = "Пользователь не найден"});

            var loginResult = await _signInManager.PasswordSignInAsync(
                loginModel.Email,
                loginModel.Password,
                lockoutOnFailure: false,
                isPersistent: true
                );

            if(loginResult.Succeeded) { return Ok("Вход выполнен"); }
            return Unauthorized(new {Error = "Неверный email или пароль"});
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
