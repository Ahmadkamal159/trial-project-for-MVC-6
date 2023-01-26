using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using trial_project_for_MVC_Core.Models;
using trial_project_for_MVC_Core.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace trial_project_for_MVC_Core.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }

        public AccountController(UserManager<AppUser> _user,SignInManager<AppUser> _signInManager)
        {
            UserManager = _user;
            SignInManager = _signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ViewModelRegisteration viewModelRegisteration)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new();
                user.UserName = viewModelRegisteration.UserName.ToLower();
                user.Email = viewModelRegisteration.Email;
                user.PhoneNumber = viewModelRegisteration.PhoneNumber;
                IdentityResult result = await UserManager.CreateAsync(user, viewModelRegisteration.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);
                 
                    return RedirectToAction("Index", "University");
                }
                else
                {
                    int i = 1;
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError($"{i}- ", error.Description);
                        i++;
                    }
                }
            }
            return View(viewModelRegisteration);
        }


        public IActionResult Login(string ReturnUrl = "~/university/index")
        {
            ViewData["redirect"] = ReturnUrl;
            return View();
        }
        
        
        [HttpPost]

        public async Task<IActionResult> Login(ViewmodelLogin viewmodelLogin,string ReturnUrl = "~/university/index")
        {
            ModelState.Remove("ReturnUrl");
            if (ModelState.IsValid)
            {
                AppUser userbyemail = await UserManager.FindByEmailAsync(viewmodelLogin.UserName);

                AppUser userbyusername = await UserManager.FindByNameAsync(viewmodelLogin.UserName.ToLower());
                if (userbyusername != null)
                {
                    SignInResult result= await SignInManager.PasswordSignInAsync(userbyusername, viewmodelLogin.Password, viewmodelLogin.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid username or password");
                    }
                }
                else if( userbyemail != null)
                {
                    SignInResult result = await SignInManager.PasswordSignInAsync(userbyemail, viewmodelLogin.Password, viewmodelLogin.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid username or password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid username or password");
                }
            }
            return View(viewmodelLogin);
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
