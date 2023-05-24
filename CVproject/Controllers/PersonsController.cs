using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVproject.Models;
using Microsoft.AspNetCore.Identity;
using CVproject.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Build.ObjectModelRemoting;
using Castle.Core.Resource;
using Newtonsoft.Json;

namespace CVproject.Controllers
{
    public class PersonsController : Controller
    {
        private readonly CvContext _context;

        private readonly UserManager<Person> _userManager;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public List<Person> searchList;

        public PersonsController(CvContext context, UserManager<Person> userManager)
        {
            _context = context;
            _userManager = userManager;
            searchList = new List<Person>();
        }

      

        // GET: Persons

        [HttpGet]
        public async Task<IActionResult> Index(string searchString1, string searchString2)
        {
            List<Person> personListAll = _context.Users.Include(p => p.CV).ThenInclude(c => c.Competences).ToList();
            List<Person> personsListPrivate = _context.Users.Include(p => p.CV).ThenInclude(c => c.Competences).Where(p => !p.IsPrivate).ToList();

            var searches = new List<string>();
            if (!String.IsNullOrEmpty(searchString1))
            {
                searches.Add("\"" + searchString1 + "\" ");
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                searches.Add("\"" + searchString2 + "\"");
            }
                

            ViewBag.Searches = searches;

            // Both strings are null or empty
            if (String.IsNullOrEmpty(searchString1) && String.IsNullOrEmpty(searchString2))
            {
                PersonSearchViewModel viewmodel = new PersonSearchViewModel
                {
                    persons = personListAll
                };
                if (!User.Identity.IsAuthenticated)
                {
                    viewmodel.persons = personsListPrivate;
                }

                return View(viewmodel);
            }

            // String2 is null or empty
            if (!String.IsNullOrEmpty(searchString1) && String.IsNullOrEmpty(searchString2))
            {
                PersonSearchViewModel viewmodel = new PersonSearchViewModel
                {
                    persons = personListAll.Where(u => u.Name.IndexOf(searchString1, StringComparison.OrdinalIgnoreCase) >= 0).ToList()

                };

                if (!User.Identity.IsAuthenticated)
                {
                    viewmodel.persons = personsListPrivate.Where(u => u.Name.IndexOf(searchString1, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                return View(viewmodel);
            }


            //None are null or empty
            if (!String.IsNullOrEmpty(searchString1) && !String.IsNullOrEmpty(searchString2))
            {

                PersonSearchViewModel viewmodel = new PersonSearchViewModel
                {
                    persons = personListAll.Where(u => u.Name.IndexOf(searchString1, StringComparison.OrdinalIgnoreCase) >= 0)
                        .Where(u => u.CV.Competences.Any(c => c.Name.IndexOf(searchString2, StringComparison.OrdinalIgnoreCase) >= 0)).ToList()
                };
                if (!User.Identity.IsAuthenticated)
                {
                    viewmodel.persons = personsListPrivate.Where(u => u.Name.IndexOf(searchString1, StringComparison.OrdinalIgnoreCase) >= 0)
                        .Where(u => u.CV.Competences.Any(c => c.Name.IndexOf(searchString2, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
                }
                return View(viewmodel);
            }


            // String1 is null or empty
            if (String.IsNullOrEmpty(searchString1) && !String.IsNullOrEmpty(searchString2))
            {
                PersonSearchViewModel viewmodel = new PersonSearchViewModel
                {
                    persons = personListAll.Where(u => u.CV.Competences.Any(c => c.Name.IndexOf(searchString2, StringComparison.OrdinalIgnoreCase) >= 0)).ToList()
                        
                };
                if (!User.Identity.IsAuthenticated)
                {
                    viewmodel.persons = personsListPrivate.Where(u => u.CV.Competences.Any(c => c.Name.IndexOf(searchString2, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
                }
                return View(viewmodel);
            }
            return View(personListAll);

        }


  
      

        private bool PersonExists(string id)
        {
          return _context.Users.Any(e => e.Id.Equals( id));
        }

        public IActionResult ChangePassword()
        {
            return View();  
        }

        [HttpGet]
        public IActionResult MyPage()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var _cv = _context.Cvs.Where(c => c.Id.Equals(user.CvId)).FirstOrDefault();

            var nrOfViews = CVsController.GetNumberOfViewsAsync(_cv.Id).Result;
            ViewBag.NrOfViews = nrOfViews;

            var viewmodel = new CvPersonViewModel
            {
                person = user,
                cv = _cv
            };

            

            var memberList = _context.ProjectMembers.ToList();
            var projectList = _context.Project.ToList();
            var userList = _context.Users.ToList();

            var projectsOfActiveUsers = from p in projectList
                                        join u in userList on p.ProjectOwner equals u.Id
                                        where u.IsActive == true
                                        select p;

            var proj = from p in projectsOfActiveUsers
                       join m in memberList on p.Id equals m.ProjectId
                       join u in userList on m.PersonId equals u.Id
                       where u.Id == user.Id
                       select p;

            ViewBag.Projects = proj;


            var owner = _context.Project.Where(p => p.ProjectOwner.Equals(user.Id));
            ViewBag.ProjectsOwner = owner;


            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult MyPage(Person person)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            user.Name = person.Name;
            user.Email = person.Email;
            user.Github = person.Github;
            user.IsPrivate = person.IsPrivate;


            //Code to Upload image
            try { 

                byte[] bytes = null; 

                if (person.ImageFile != null)
                {
    

                    using (Stream fileStream = person.ImageFile.OpenReadStream())
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fileStream))
                        {
                            bytes = binaryReader.ReadBytes((Int32)fileStream.Length);
                        }
                    }

                    user.Picture = Convert.ToBase64String(bytes, 0, bytes.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }

            var memberList = _context.ProjectMembers.ToList();
            var projectList = _context.Project.ToList();
            var userList = _context.Users.ToList();

            var projectsOfActiveUsers = from p in projectList
                                        join u in userList on p.ProjectOwner equals u.Id
                                        where u.IsActive == true
                                        select p;

            var proj = from p in projectsOfActiveUsers
                       join m in memberList on p.Id equals m.ProjectId
                       join u in userList on m.PersonId equals u.Id
                       where u.Id == user.Id
                       select p;

            ViewBag.Projects = proj;
            var owner = _context.Project.Where(p => p.ProjectOwner.Equals(user.Id));

            ViewBag.ProjectsOwner = owner;



            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                var current_User = _userManager.GetUserAsync(HttpContext.User).Result;

                var _cv = _context.Cvs.Where(c => c.Id.Equals(current_User.CvId)).FirstOrDefault();

                var viewmodel = new CvPersonViewModel
                {
                    person = current_User,
                    cv = _cv

                };

                return View(viewmodel);
            }

            var model = new CvPersonViewModel
            {
                person = person,
                cv = _context.Cvs.Where(c => c.Id.Equals(user.CvId)).FirstOrDefault()
            };

            return View(model);
        }


    }
}
