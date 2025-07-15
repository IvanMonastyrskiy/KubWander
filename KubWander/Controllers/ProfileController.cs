using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using KubWander.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KubWander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDbContext _context;

        public ProfileController(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<ProfileController> logger, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }
        [HttpGet("users")]
        [Produces("application/json")]
        public async Task<IActionResult> User_profile()
        {
            var id = _userManager.GetUserId(User);
            var email = User.Identity?.Name;
            var user = await _userManager.FindByEmailAsync(email);
            var count_quests_user = _context.UserQuests.Count(u => u.UserId == id && u.Status == "Выполнено");
            var count_photos_user = _context.Photos.Count(p => p.UserId == id);
            if (user == null) return Unauthorized();
            //return Ok(new { User = user.Name, user.Email, user.Points, count_quests_user, count_photos_user });
            return Content(JsonConvert.SerializeObject(new
            {
                User = user.Name,
                user.Email,
                user.Points,
                user.AvatarUrl,
                count_quests_user,
                count_photos_user
            }), "application/json; charset=utf-8");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

    }
}
