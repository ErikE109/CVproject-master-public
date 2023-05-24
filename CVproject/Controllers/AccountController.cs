using CVproject.Models;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CVproject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Person> _userManager;
        private SignInManager<Person> _signInManager;
        private CvContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(UserManager<Person> userManager, SignInManager<Person> signInManager, CvContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context; 
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IActionResult LogIn()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
            
        }

        [HttpGet]
        public IActionResult Registrera()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        {
            var user = _context.Users.Where(u => u.UserName.Equals(loginViewModel.UserName)).FirstOrDefault();
            
            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    ModelState.AddModelError(",", "Wrong username");
                    return View();
                }

                if (!user.IsActive)
                {
                    ModelState.AddModelError(",", "This account is disabled");
                    return View(loginViewModel);
                }

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password, isPersistent: loginViewModel.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(",", "Wrong password");
                }
            }
           
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Registrera(LoginRegisterViewModel loginRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                CV newCV = new CV();
                _context.Cvs.Add(newCV);
                _context.SaveChanges();

                Person newUser = new Person()
                    {
                        UserName = loginRegisterViewModel.UserName,
                        Name = loginRegisterViewModel.Name,
                        Email = loginRegisterViewModel.Email,
                
                        CvId = newCV.Id
                    };
               

                var result = await _userManager.CreateAsync(newUser, loginRegisterViewModel.Password);
                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: true);
    
                    Console.WriteLine("hello");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginRegisterViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel passwordViewModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _userManager.FindByIdAsync(userId);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, passwordViewModel.Password);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Diactivate()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId != null)
            {
                var user = _context.Users.Find(userId);
                user.IsActive = false;
                _context.Users.Update(user);
                _context.SaveChanges();
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            TempData["message"] = "Could not diactivate";
            return RedirectToAction("Mypage", "Persons");
        }
    }
}
