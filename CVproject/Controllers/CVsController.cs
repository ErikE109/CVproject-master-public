using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVproject.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using CVproject.Models.XML;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CVproject.Controllers
{
    public class CVsController : Controller
    {
        private readonly CvContext _context;
        private readonly UserManager<Person> _userManager;
        private readonly SerializerForXml _serializerForXml;

        private HttpClient _httpClient;
        public CVsController(CvContext context, UserManager<Person> userManager, HttpClient httpClient, SerializerForXml serializerForXml)
        {
            _context = context;
            _userManager = userManager;
            _httpClient = httpClient;
            _serializerForXml = serializerForXml;   
        }

        // GET: CVs
        [HttpGet]
      
        public IActionResult Index(string id) 
        {
           
            var person = _context.Users.Where(x =>x.Id.Equals(id)).FirstOrDefault();
            var _cv = _context.Cvs.Where(c => c.Id.Equals(person.CvId)).FirstOrDefault();

            var currentUsersOrientations = _context.Educations.Where(e => e.CvId.Equals(_cv.Id)).Select(e => e.Orientation).ToList();

            var userList = _context.Users.ToList();
            var cvList = _context.Cvs.ToList();
            var eduList = _context.Educations.ToList();

            var ran = new Random();

            var similarUserList = from u in userList
                                  join c in cvList on u.CvId equals c.Id
                                  join e in eduList on c.Id equals e.CvId
                                  where !u.CvId.Equals(person.CvId) && e.Orientation.Equals(currentUsersOrientations.FirstOrDefault())
                                  select u;
                                  
  
           

            var similarRandomUser = similarUserList.OrderBy(x => ran.Next()).FirstOrDefault();

            ViewBag.Orientation = currentUsersOrientations.FirstOrDefault();
            ViewBag.PersonWithSimilarCV = null;
            if (similarRandomUser != null)
            {
                ViewBag.PersonWithSimilarCV = similarRandomUser;

            }





            _cv.NumberOfViews++;
            _context.SaveChanges();

           
            var viewmodel = new CvPersonViewModel
            {
                person = person,
                cv = _cv,
            };


            var memberList = _context.ProjectMembers.ToList();
            var projectList = _context.Project.ToList();

            var projectsOfActiveUsers = from p in projectList
                                        join u in userList on p.ProjectOwner equals u.Id
                                        where u.IsActive == true
                                        select p;


            var proj = from p in projectsOfActiveUsers
                       join m in memberList on p.Id equals m.ProjectId
                       join u in userList on m.PersonId equals u.Id
                       where u.Id == id
                       select p;

            ViewBag.Projects = proj;

            var owner = _context.Project.Where(p => p.ProjectOwner.Equals(viewmodel.person.Id));

            ViewBag.ProjectsOwner = owner;
            return View(viewmodel);
        }


        private bool CVExists(int id)
        {
            return _context.Cvs.Any(e => e.Id == id);
        }

        public async static Task<int> GetNumberOfViewsAsync(int id)
        {
            HttpClient _httpClient = new HttpClient();

            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7211/cv/{id}");
            string data = await response.Content.ReadAsStringAsync();
            var opstions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            int viewers = JsonSerializer.Deserialize<int>(data, opstions);

            return viewers;

        }

        public IActionResult CreateXml(string? id)
        {
            var person = _context.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();
            var _cv = _context.Cvs.Where(c => c.Id.Equals(person.CvId)).FirstOrDefault();
            XMLmodel model = new XMLmodel()
            {
                Name = person.Name,
                Picture = person.Picture,
                CvId = person.CvId,
                IsPrivate = person.IsPrivate,
                Projects = MapToXmlProject(person),
                CvModelXml = MapToXmlCv(_cv)

            };

            _serializerForXml.Serialize(model);
            TempData["message"] = "You have downloded xml";
            return RedirectToAction("Index", new { id = id });

        }

        private List<XmlProjectModel> MapToXmlProject(Person person)
        {
            List<XmlProjectModel> projects = new List<XmlProjectModel>();

            foreach( var item in person.Projects) {
                XmlProjectModel model = new XmlProjectModel()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Id = item.Id,
                    ProjectOwner = item.ProjectOwner,
                };
                projects.Add(model);

            }
            return projects;
        }

        private XmlCvModel MapToXmlCv(CV personCV)
        {
            List<XmlCompetenceModel> competenses = new List<XmlCompetenceModel>();
            List<XmlEducationModel> educations = new List<XmlEducationModel>();
            List<XmlExperienceModel> experience = new List<XmlExperienceModel>();

            foreach (var item in personCV.Competences)
            {
                XmlCompetenceModel model = new XmlCompetenceModel()
                {
                    Name = item.Name,
                    Id = item.Id,
                    CvId = item.CvId,
                };
                competenses.Add(model);

            }

            foreach (var item in personCV.Educations)
            {
                XmlEducationModel model = new XmlEducationModel()
                {
                    Id = item.Id,
                    University = item.University,
                    StartYear = item.StartYear,
                    EndYear = item.EndYear,
                    Orientation = item.Orientation,
                    CvId = item.CvId,
                };
                educations.Add(model);

            }

            foreach (var item in personCV.Experiences)
            {
                XmlExperienceModel model = new XmlExperienceModel()
                {
                    Id = item.Id,
                    Employer = item.Employer,
                    Title = item.Title,
                    StartYear= item.StartYear,
                    EndYear= item.EndYear,
                    CvId = item.CvId,
                };
                experience.Add(model);

            }

            XmlCvModel xmlCvModel = new XmlCvModel()
            {
                Id = personCV.Id,
                NumberOfViews = personCV.NumberOfViews,
                Competences = competenses,
                Educations = educations,
                Experiences = experience,

            };
            return xmlCvModel;
        }

       
    }
}
