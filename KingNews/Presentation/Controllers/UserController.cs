﻿using Application.Services;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly EmailSenderService _sender;

        public UserController(UserManager<User> userManager, SignInManager<User> signManager, EmailSenderService sender)
        {
            _userManager = userManager;
            _signInManager = signManager;
            _sender = sender;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel regModel)
        {
            if (!ModelState.IsValid)
                return View();

            if (await _userManager.IsNameAlreadyExistAsync(regModel.Email))
            {
                ModelState.AddModelError("Uniq_Mail", "User with such login already exist");
                return View();
            }

            var user = new User
            {
                Email = regModel.Email,
                UserName = regModel.Email,
                Profile = new UserProfile()
            };

            await _userManager.CreateAsync(user, regModel.Password);
            var res = await _signInManager
                .PasswordSignInAsync(user, regModel.ConfirmPassword, false, false);

            if (!res.Succeeded)
            {
                ModelState.AddModelError("Creator_Error", "Unable to create user.");
                return View();
            }

            if (await TrySendVerification(user))
                return View("OnEmailConfirm");

            return RedirectToAction("Profile", "Office");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        private async Task<bool> TrySendVerification(User user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code = code },
                protocol: HttpContext.Request.Scheme);

                await _sender.SendEmailAsync(user.Email, "Confirm your account",
                    $"Verify your email on click by <a href='{callbackUrl}'>link</a>");
                return true;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            ViewBag.Errors = new List<string>();

            if (userId == null || code == null)
            {
                ViewBag.Errors.Add("Incorrect input parameters");
                return View("OnEmailConfirm");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.Message.Add("User not exist, or token expired");
                return View("OnEmailConfirm");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
                return RedirectToAction("Profile", "Office");
            else
            {
                ViewBag.Message.Add("I`m don`t know what happening, but result !Succeeded");
                return View("OnEmailConfirm");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {

                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Please confirm your email!");
                    }

                    var res = await _signInManager.PasswordSignInAsync(model.Email,
                        model.Password,
                        model.RememberMe,
                        false);

                    if (res.Succeeded)
                    {
                        return RedirectToAction("Profile", "Office");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect login or password.");
                }
            }
            return RedirectToAction("Register", "Account");
        }
    }
}
