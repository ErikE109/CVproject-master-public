using CVWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
//using System.Web.Http;

namespace CVWebAPI.Controllers
{
    
    public class CvsController : Controller
    {
        private CvContext _context;

        public CvsController(CvContext cvContext)
        {
            _context = cvContext;
        }

        [HttpGet("Cv/{id}")]
        public int GetViewers(int id)
        {
            var _cv = _context.Cvs.Find(id);
            return _cv.NumberOfViews;
        }
    }
}
