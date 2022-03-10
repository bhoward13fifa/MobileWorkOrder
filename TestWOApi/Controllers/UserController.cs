using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOrderDataManager.Library.Models;
using WorkOrderDataManager.Library.DataAccess;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TestWOApi.Data;

namespace TestWOApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IConfiguration config)
        {
            _config = config;
            _context = context;
            _userManager = userManager;

        }
        [HttpGet]
        public UserModel GetById()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //RequestContext.Principal.Identity.GetUserId()
            UserData data = new UserData(_config);

            return data.GetUserById(userId).First();
        }
    }
}
