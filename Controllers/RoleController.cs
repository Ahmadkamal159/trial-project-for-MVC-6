using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using trial_project_for_MVC_Core.ViewModels;

namespace trial_project_for_MVC_Core.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly UserManager<IdentityUser> userManager;


        public RoleController(RoleManager<IdentityRole> _RoleManager, UserManager<IdentityUser> _usermanager)
        {
            userManager = _usermanager;
            RoleManager = _RoleManager;
        }
        // GET: RoleController
        public IActionResult Index()
        {
            List<ViewModelRole> rolesToView = new();

            foreach (var role in RoleManager.Roles)
            {
                ViewModelRole v = new();
                v.RoleName = role.Name;
            }

            return View(rolesToView);
        }


        public IActionResult AddRole()
        {
            ViewModelRole role = new();
            return View(role);
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(ViewModelRole role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new();
                identityRole.Name = role.RoleName;
                IdentityResult res = await RoleManager.CreateAsync(identityRole);
                if (res.Succeeded)
                {
                    RoleManager.CreateAsync(identityRole);

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    foreach (var error in res.Errors)
                        ModelState.AddModelError("", error.Description);
                }

            }

            return View(role);
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
