using Assignment.DAL.Models.IdentityModels;
using Assignment.PL.Utilities;
using Assignment.PL.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.PL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager,
                                   SignInManager<ApplicationUser> _signInManager)
                : Controller
    {
        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userToAdd = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var res = _userManager.CreateAsync(userToAdd, model.Password).Result;

            if (res.Succeeded)
                return RedirectToAction("Login");
            else
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

        }

        #endregion

        #region LogIn

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user is not null)
            {
                var incorrectPass = _userManager.CheckPasswordAsync(user, model.Password).Result;

                if (incorrectPass)
                {
                    var res = _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;

                    if (res.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "Your Account is not Allowed");
                    if (res.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your Account is Locked");


                    if (res.Succeeded)
                        return RedirectToAction(nameof(HomeController.Index), "Home");

                }
            }
            else
                ModelState.AddModelError(string.Empty, "InValid Login");

            return View();
        }

        #endregion

        #region LogOut

        [HttpGet]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        #endregion


        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email).Result;

                if(user is not null)
                {
                    //Create Reset Password Link
                    //BaseUrl/Account/ResetPasswordLink?email=xxxxx@gmail.com
                    var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var resetPasswordLink = Url.Action("ResetPasswordLink", "Account", new { email = model.Email }, Request.Scheme);

                    //Create Email
                    var mail = new Email()
                    {
                        To = model.Email,
                        Subject = "Reset Password",
                        //Body = "--------Reset Your Password-----------"
                        Body = resetPasswordLink

                    };

                    //Send Email
                    var res = EmailSettings.SendEmail(mail);
                    if (res)
                        return RedirectToAction("CheckYourInbox");
                }


            }
            ModelState.AddModelError(string.Empty, "InValid Operation");
            return View(nameof(ForgetPassword), model);


        }

        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }

        #region Reset Password

        [HttpGet]
        public IActionResult ResetPasswordLink(string email, string token)
        {
            TempData["email"] = email;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]
        public IActionResult ResetPasswordLink(ResetPasswordViewModel model)
        {
            if(!ModelState.IsValid)
               return View(model);

            var email = TempData["email"] as string;
            var token = TempData["token"] as string;

            var user = _userManager.FindByEmailAsync(email).Result;

            if(user is not null)
            {
               var res = _userManager.ResetPasswordAsync(user, token, model.Password).Result;

                if (res.Succeeded)
                    return RedirectToAction(nameof(Login));
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }

            return View(model);
        }

        #endregion
    }
}
