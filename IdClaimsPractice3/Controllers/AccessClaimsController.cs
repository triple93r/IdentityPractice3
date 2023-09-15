using IdClaimsPractice3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace IdClaimsPractice3.Controllers
{
    [Authorize(Roles = "Admin, Employees")]
    public class AccessClaimsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public AccessClaimsController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AssignClaims()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AssignClaims(string useremail, string claimsnm, string clvalue)
        {
            //var userid = _userManager.GetUserId(User);
            //var userEmail = await _userManager.FindByIdAsync(userid);

            var user = await _userManager.FindByNameAsync(useremail);

            await _userManager.AddClaimAsync(user, new Claim(claimsnm, clvalue));

            return View("ClaimsDone");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ClaimsDone()
        {
            return View();
        }

        [Authorize(Policy = "HROnly")]
        public async Task<IActionResult> Hrpage()
        {
            return View();
        }

        [Authorize(Policy = "ManangerOnly")]
        public async Task<IActionResult> Managerpage()
        {
            return View();
        }

        public IActionResult Anonymous()
        {
            return View();
        }
    }
}
