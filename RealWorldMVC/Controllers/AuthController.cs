using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealWorldMVC.Models;


namespace RealWorldMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            return View(new UserRegistrationDto());
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userIdentity = await _userManager.FindByEmailAsync(registrationDto.Email);
                if (userIdentity == null)
                {
                    IdentityUser user = new IdentityUser
                    {
                        UserName = registrationDto.Username,
                        Email = registrationDto.Email,
                        EmailConfirmed = true,
                    };

                    var result = await _userManager.CreateAsync(user, registrationDto.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(registrationDto);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(registrationDto);
                }
            }
            return View(registrationDto);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            //UserLoginDto model = new UserLoginDto();
            return View(new User());
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("ErrorMsg", "Email not confirmed yet");
                    return View(model);

                }
                if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("ErrorMsg", "Invalid credentials");
                    return View(model);

                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
                //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "RegularUser"));
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("ErrorMsg", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
