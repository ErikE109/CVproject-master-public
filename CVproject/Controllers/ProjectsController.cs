using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVproject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CVproject.ViewModels;
using Azure;

namespace CVproject.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly CvContext _context;

        private readonly UserManager<Person> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        

        public ProjectsController(CvContext context, UserManager<Person> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

        }

        // GET: Projects
      
        public async Task<IActionResult> Index()
        {
            
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            if (user != null)
            {
               
                

                var memberList = _context.ProjectMembers.ToList();
                var projectList = _context.Project.ToList();
                var userList = _context.Users.ToList();

                var proj = from p in projectList
                           join m in memberList on p.Id equals m.ProjectId
                           join u in userList on m.PersonId equals u.Id
                           where u.Id == user.Id
                           select p.Id;

                List<int> proj1 = proj.ToList();
                ViewBag.User = user;
                ViewBag.Projects = proj1;
            }


            



            return View(await _context.Project.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);



            ViewData["ProjectOwnerNames"] = _context.ProjectMembers.Where(p => p.ProjectId.Equals(id)).Select(personer =>
                personer.Person
            ).ToList();

            {


                if (project == null)
                {
                    return NotFound();
                }

                return View(project);
            }

            // GET: Projects/Create
        }
        public IActionResult Create()
        {
            ViewData["ProjectOwnerNames"] = _context.Users.Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create( ProjectViewModel projectViewModel) 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Project newProject = new Project()
            {
                Name = projectViewModel.Name,
                Description = projectViewModel.Description,
                ProjectOwner = userId
            };
            

            if (ModelState.IsValid)
            {
                _context.Add(newProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newProject);
        }

        // GET: Projects/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            ViewData["ProjectOwner"] = _context.Users.Where(u => u.Id.Equals(user.Id)).Select(u => u.Id).SingleOrDefault();
            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ProjectOwner")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'CvContext.Project'  is null.");
            }
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return _context.Project.Any(e => e.Id == id);
        }

        public async Task<IActionResult> JoinProject (int id)
        {
            var userID = _userManager.GetUserAsync(HttpContext.User).Result.Id;


            ProjectMember pm = new ProjectMember
            {
                PersonId = userID,
                ProjectId = id,
            };
            _context.ProjectMembers.AddAsync(pm);

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
                
        }

        public async Task<IActionResult> LeaveProject(int id)
        {
            var userID = _userManager.GetUserAsync(HttpContext.User).Result.Id;

            var pmItem = _context.ProjectMembers.Where(p => p.ProjectId == id && p.PersonId.Equals(userID)).FirstOrDefault();

       

            _context.ProjectMembers.Remove(pmItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        
       
    }
}
