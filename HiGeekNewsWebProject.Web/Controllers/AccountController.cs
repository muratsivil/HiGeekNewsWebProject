using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HiGeekNewsWebProject.Associate.DTOs;
using HiGeekNewsWebProject.Business.Services.Abstract;
using HiGeekNewsWebProject.DataAccess.Repository.Concrete;
using HiGeekNewsWebProject.Entites.Entity;
using HiGeekNewsWebProject.Kernel.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HiGeekNewsWebProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IPasswordHasher<AppUser> _passwordHasser;

        public AccountController(IAppUserService appUserService,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IPasswordHasher<AppUser> passwordHasser)
        {
            this._appUserService = appUserService;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._passwordHasser = passwordHasser;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {  
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            _appUserService.UserCreate(registerDTO);
            return View();
        }



        //public IActionResult Login()
        //{
           
        //    return View();
        //}
    }
}
