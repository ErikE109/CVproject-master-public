using CVproject.Models;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;


namespace CVproject.Controllers
{
    public class HomeController : Controller
    {
      
        private CvContext _context;

        public HomeController( CvContext context) 
        {
           
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           
            Project lastProject = null;

                if (_context.Project.Count() > 0)
                {

                    lastProject = _context.Project.OrderBy(p => p.Id).LastOrDefaultAsync().Result;

                    //Get person of last projekt to check if isActive
                    var person = _context.Users.Where(x => x.Id.Equals(lastProject.Person.Id)).FirstOrDefault();
                    if (person.IsActive) { 
                        var lastProjectID = lastProject.Id;

                        var projectOwner = lastProject.Person;


                        ViewBag.LastProject = lastProject;
                        ViewBag.LastProjectOwner = projectOwner.Name;

                    }
            }
            var ran = new Random();
            var users = await _context.Users.ToListAsync();
            List<Person> randomlist = new List<Person>();

            if ((!User.Identity.IsAuthenticated))
            {
                randomlist = users.Where(x => !x.IsPrivate).OrderBy(x => ran.Next()).Take(4).ToList();
            }
            else
            {
                randomlist = users.OrderBy(x => ran.Next()).Take(4).ToList();
            }
            

            List<CvPersonViewModel> results = new List<CvPersonViewModel>();

            foreach (var user in randomlist)
            { results.Add(
                new CvPersonViewModel
                {
                    person = user,
                    cv = user.CV,
                    education = user.CV.Educations.OrderByDescending(u => u.EndYear).FirstOrDefault(),
                    experience = user.CV.Experiences.OrderByDescending(u => u.EndYear).FirstOrDefault(),
                    competences = user.CV.Competences.OrderByDescending(u => u.Id).Take(3).ToList()
                });
                
                
            }
            var viewModel = new HomeViewModel
            {
                Users = results,
                lastproject = lastProject,
            };
            return View(viewModel);
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}