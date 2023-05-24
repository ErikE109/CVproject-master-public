using CVproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CVproject.Controllers
{
    public class EducationsController : Controller
    {
        private readonly CvContext _context;

        public EducationsController(CvContext context)
        {
            _context = context;
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AddEducation(Education model)
        {
           
                if (ModelState.IsValid)
                {
                    if (model.EndYear < model.StartYear)
                    {
                        TempData["errorMessage"] = "Please Make Sure End Year of Education Is After Start Year";
                    }
                    else
                    {
                    _context.Educations.Add(model);
                    _context.SaveChanges();

                    TempData["errorMessage"] = "";
                    }
                   
                }
            
          
                else
            {
                TempData["errorMessage"] = "Please Complete All Fields Before Saving";
               
               
            }

            return RedirectToAction("MyPage", "Persons");

        }




        // POST: EducationsController/Edit/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            Education education = _context.Educations.Find(id);
            return PartialView("_EducationEdit", education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEducation([Bind("Id,University,StartYear, EndYear, Orientation,CvId")] Education education)
        {
            
            if (ModelState.IsValid)
            {
                    _context.Educations.Update(education);
                    await _context.SaveChangesAsync();

                TempData["errorMessage"] = "";

                return RedirectToAction("MyPage", "Persons");
            }
            
            else
                {
                    TempData["errorMessageEdit"] = "Please Complete All Fields Before Saving";
                ViewBag.ModalOpen = "Open";
                return RedirectToAction("MyPage", "Persons");

            }
            

        }

        // GET: EducationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
          
            if (_context.Educations == null)
            {
                return Problem("Entity set 'CvContext.Educations'  is null.");
            }
          
            var education = await _context.Educations.FindAsync(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("MyPage", "Persons");
        }

        
    }
}
