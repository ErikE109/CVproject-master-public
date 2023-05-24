using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVproject.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CVproject.ViewModels;
using Microsoft.Extensions.Options;

namespace CVproject.Controllers
{
    public class MessagesController : Controller
    {
        private readonly CvContext _context;

        private HttpClient _httpClient;

        private readonly UserManager<Person> _userManager;

        public MessagesController(CvContext context, HttpClient httpClient, UserManager<Person> userManager)
        {
            _context = context;
            _httpClient = httpClient;
            _userManager = userManager; 
        }

        //GET: Messages from API
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try { 
                HttpResponseMessage response = await _httpClient.GetAsync($"message/{userId}" );
                string data = await response.Content.ReadAsStringAsync();
                var opstions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                List<Message> messageList = JsonSerializer.Deserialize<List<Message>>(data, opstions).ToList();

                return View(messageList);
            }
            catch( Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }

            ModelState.AddModelError(",", "Can't get messages");
            return View();
        }


        //Update message , set IsRead to true
        // GET: Messages/Details/5 API
        public async Task<IActionResult> Details(int? id)
        {
            //Get message from API
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"message/detail/{id}");
                string data = await response.Content.ReadAsStringAsync();
                var opstions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Message message = JsonSerializer.Deserialize<Message>(data, opstions);


                if (message.IsRead == false)
                {
                    //To save update
                    message.IsRead = true;

                    string messageData = JsonSerializer.Serialize(message);
                    var jsonData = new StringContent(messageData, System.Text.Encoding.UTF8, "application/json");

                    //Save via the Put method in API
                    HttpResponseMessage responseMessage = await _httpClient.PutAsync($"message/{message.Id}", jsonData);
                }

                return View(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }
            ModelState.AddModelError(",", "Can't update message to Read");
            return View();
        }

       

        // GET: Messages/Create
        public IActionResult Create(string? id)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            var model = new MessageViewModel();

            if(user != null) 
            {
                model.SenderName = user.Name;
               
            }
            model.ReceiverName = _context.Users.Find(id).Name; 
            model.ReceiverId = id;
            return View(model);
        }

        // POST: Messages/Create API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( MessageViewModel messageViewModel ) 
        {
            try
            {
                var message = new Message();
                message.SenderName = messageViewModel.SenderName;
                message.ReceiverId = messageViewModel.ReceiverId;
                message.Heading = messageViewModel.Heading;
                message.Text = messageViewModel.Text;


                if (ModelState.IsValid)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    string data = JsonSerializer.Serialize(message, options);
                    var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PostAsync($"message", contentData);
                    TempData["message"] = "Message was sent";
                    ViewBag.Message = "Message was sent";
                    return RedirectToAction("Create");
                }
                return View(messageViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }
            ModelState.AddModelError(",", "Can't send message");
            return View();
        }
     

        // GET: Messages/Delete/5 API
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"message/detail/{id}");
                string data = await response.Content.ReadAsStringAsync();
                var opstions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Message message = JsonSerializer.Deserialize<Message>(data, opstions);

                return View(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }
            ModelState.AddModelError(",", "Can't delete message");
            return View();
        }


        // POST: Messages/Delete/5 API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            //Get messaeg from API
            try
            {
                HttpResponseMessage messageResponse = await _httpClient.DeleteAsync($"message/{id}");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }
            ModelState.AddModelError(",", "Can't delete message");
            return View();
        }

        private bool MessageExists(string id)
        {
            return _context.Messages.Any(e => e.ReceiverId.Equals(id));
        }


       
    }
}
