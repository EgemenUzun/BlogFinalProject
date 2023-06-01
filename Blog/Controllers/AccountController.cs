using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.DataBase.Business.Abstract;
using Project.DataBase.Entities.Concrete;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var temp = new User();
                temp = _userService.GetbyUserName(loginViewModel.Username);
                if(temp != null)
                {
                    if(temp.Password == loginViewModel.Password)
                    {
                        HttpContext.Session.SetInt32("UserId",temp.UserID);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData.Add("message", "Password is wrong");
                }
                if (TempData["message"] == null)
                    TempData.Add("message", "Username not found");
            }
            return View(loginViewModel);
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid) 
            {
                if(_userService.GetbyUserName(registerViewModel.user.Username) == null)
                {
                    _userService.Add(registerViewModel.user);
                    TempData.Add("message", "User Created");
                    return RedirectToAction("Login");
                }
                    
                TempData.Add("message", "Username is using");
            }
            return View(registerViewModel);
        }
        public ActionResult LogOff()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}
