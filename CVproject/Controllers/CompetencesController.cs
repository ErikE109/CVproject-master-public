using CVproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.Controllers
{
    public class CompetencesController : Controller
    {
        private readonly CvContext _context;
        public CvViewModel cmv { get; set; }

        public CompetencesController(CvContext context) {
            _context = context;

           cmv = new CvViewModel
            {
                Competences = _context.Competences.ToList()
            };
        }


        public ActionResult _CompDetailsPartial()
        {
            return View(cmv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCompetence(Competence model)
        {
            
                _context.Competences.Add(model);
                _context.SaveChanges();
            

            return RedirectToAction("MyPage", "Persons");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Competences == null)
            {
                return Problem("Entity set 'CvContext.Competences'  is null.");
            }
            var comp = await _context.Competences.FindAsync(id);
            if (comp != null)
            {
                _context.Competences.Remove(comp);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyPage", "Persons");
        }


    }
}
