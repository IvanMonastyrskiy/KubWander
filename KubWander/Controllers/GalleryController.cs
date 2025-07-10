using KubWander.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KubWander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDbContext _context;

        public GalleryController(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<ProfileController> logger, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }
        // GET: api/<GalleryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var id = _userManager.GetUserId(User);
            var email = User.Identity?.Name;
            var user = await _userManager.FindByEmailAsync(email);
            var photos = await _context.Photos.Where(p => p.UserId == id).ToListAsync();
            return Ok(photos);
        }

        // GET api/<GalleryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GalleryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GalleryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GalleryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
