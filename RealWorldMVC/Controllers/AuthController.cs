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
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterDto());
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto registrationDto)
        {
            if (ModelState.IsValid)
            {
                AppUser userIdentity = await _userManager.FindByEmailAsync(registrationDto.Email);
                if (userIdentity == null)
                {
                    AppUser user = new AppUser
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
                    ModelState.AddModelError("message", "Email already exists");
                    return View(registrationDto);
                }
            }
            return View(registrationDto);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            return View(new SignInDto());
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(SignInDto signInDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(signInDto.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("ErrorMsg", "Email not confirmed yet");
                    return View(signInDto);

                }
                if (await _userManager.CheckPasswordAsync(user, signInDto.Password) == false)
                {
                    ModelState.AddModelError("ErrorMsg", "Invalid credentials");
                    return View(signInDto);

                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, signInDto.Password, false, false);
                //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "RegularUser"));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("ErrorMsg", "Invalid login attempt");
                    return View(signInDto);
                }
            }
            return View(signInDto);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
