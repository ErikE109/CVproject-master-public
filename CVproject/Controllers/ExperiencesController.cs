using CVproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.Controllers
{
    public class ExperiencesController : Controller
    {
        private readonly CvContext _context;

        public ExperiencesController(CvContext ctx)
        {
            _context = ctx;
        }
        // GET: ExperiencesController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddExperience(Experience model)
        {
            if (ModelState.IsValid)
            {
                if (model.EndYear < model.StartYear)
                {
                    TempData["errorMessageExp"] = "Please Make Sure End Year Is After Start Year";
                }
                else
                {
                    _context.Experiences.Add(model);
                    _context.SaveChanges();

                    TempData["errorMessageExp"] = "";
                }
            }
            else
            {
                TempData["errorMessageExp"] = "Please Complete All Fields Before Saving";
            }


            return RedirectToAction("MyPage", "Persons");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            Experience experience = _context.Experiences.Find(id);


            return PartialView("_ExpEdit", experience);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExperience([Bind("Id,Employer,Title,StartYear, EndYear,CvId")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Experiences.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch
                {

                }
                return RedirectToAction("MyPage", "Persons");
            }
            return RedirectToAction("MyPage", "Persons");
        }


        // GET: EducationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            if (_context.Experiences == null)
            {
                return Problem("Entity set 'CvContext.Experiences'  is null.");
            }

            var exp = await _context.Experiences.FindAsync(id);
            if (exp != null)
            {
                _context.Experiences.Remove(exp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("MyPage", "Persons");
        }

  

    }
}
