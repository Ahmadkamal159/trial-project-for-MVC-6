using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using trial_project_for_MVC_Core.Models;
using trial_project_for_MVC_Core.ViewModels;

namespace trial_project_for_MVC_Core.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly UserManager<AppUser> userManager;


        public RoleController(RoleManager<IdentityRole> _RoleManager, UserManager<AppUser> _usermanager)
        {
            userManager = _usermanager;
            RoleManager = _RoleManager;
        }

        public IActionResult Index()
        {
            List<ViewModelRole> rolesToView = new();

            foreach (var role in RoleManager.Roles)
            {
                ViewModelRole v = new();
                v.RoleName = role.Name;
                v.Id=role.Id;
                rolesToView.Add(v);
            }

            return View(rolesToView);
        }


        public IActionResult AddRole()
        {
            ViewModelRole role = new();
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole([include: RoleName] ViewModelRole role)
        {
            ModelState.Remove("Id"); 
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

        public ActionResult Edit(string? Id)
        {
            var role= RoleManager.Roles.FirstOrDefault(x=>x.Id==Id);
            if (Id != role.Id)
            {
                return Content("invalid role ID");
            }
            ViewModelRole r = new() { RoleName = role.Name, Id = role.Id };
            return View(r);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(ViewModelRole r)
        {
            if(ModelState.IsValid)
            {
                IdentityRole idenrole = RoleManager.Roles.FirstOrDefault(x=>x.Id==r.Id);
                idenrole.Name = r.RoleName;
                IdentityResult res= await RoleManager.UpdateAsync(idenrole);
                if (res.Succeeded)
                {

                    await RoleManager.UpdateAsync(idenrole);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    foreach(var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        public async Task<ActionResult> Delete(string? id)
        {

            if (await RoleManager.FindByIdAsync(id)==null)
            {
                return Content("there's No Item to delete");
            }
            IdentityRole iden = RoleManager.Roles.FirstOrDefault(x => x.Id == id);

            await RoleManager.DeleteAsync(iden);

            return RedirectToAction("Index");
        }
        
    }
}
