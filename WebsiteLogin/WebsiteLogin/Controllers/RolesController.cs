using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebsiteLogin.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _role;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _role=roleManager;  
        }
        public IActionResult Index()
        {
            var roles  = _role.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if(!_role.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _role.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }


    }
}
