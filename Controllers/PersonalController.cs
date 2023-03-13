using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MotoHelp.Models;
using MotoHelp.ViewModels;
using System.Security.Claims;
using MotoHelp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MotoHelp.Controllers
{
    [Route("personal/{action=Index}")]
    public class PersonalController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public PersonalController(DBContent dBContent, UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr) {
            userManager = userMgr;
            signInManager = signinMgr;
        }
        [HttpGet]
        [ActionName("login")]
        public IActionResult Login(string? ReturnUrl)
        {
            return View(new LoginModel { ReturnUrl = ReturnUrl});
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email), "Неверный логин или пароль");
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //    public async Task<IActionResult> Login(LoginModel model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            IdentityUser user = await userManager.FindByNameAsync(model.Email); 
        //            if (user != null)
        //            {
        //                await Authenticate(model.Email); // аутентификация
        //                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
        //                {
        //                    return Redirect(model.ReturnUrl);
        //                }
        //                else
        //                    return RedirectToAction("Index", "Personal");
        //            }
        //            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //        }
        //        return View(model);
        //    }
        //    [HttpGet]
        //    public IActionResult Register()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Register(RegisterModel model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            IdentityUser user = await dBContent.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        //            if (user == null)
        //            {
        //                // добавляем пользователя в бд
        //                dBContent.Users.Add(new IdentityUser { Email = model.Email, PasswordHash = model.Password });
        //                await dBContent.SaveChangesAsync();

        //                await Authenticate(model.Email); // аутентификация

        //                return RedirectToAction("Index", "Home");
        //            }
        //            else
        //                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //        }
        //        return View(model);
        //    }

        //    private async Task Authenticate(string userName)
        //    {
        //        // создаем один claim
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        //        };
        //        // создаем объект ClaimsIdentity
        //        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //        // установка аутентификационных куки
        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //    }

        //    public async Task<IActionResult> Logout()
        //    {
        //        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //        return RedirectToAction("login", "Personal");
        //    }
    }
}
