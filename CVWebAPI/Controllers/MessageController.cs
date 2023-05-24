using CVWebAPI.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CVWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private CvContext _context;

        public MessageController(CvContext context)
        {
            _context = context;
        }


        //Get all messages from one user
        [HttpGet("{id}")] 
        public List<Message> GetAllMessages(string id)
        {
            return _context.Messages.Where(r => r.Receiver.Id.Equals(id)).ToList();
        }

        //Get message by id
        [HttpGet("Detail/{id}")]
        public Message GetMessage(int id)
        {
            return _context.Messages.FirstOrDefault(m => m.Id == id);
        }

        //Add one message
        [HttpPost]
        public void PostMessage(Message message)
        {
            if(ModelState.IsValid)
            {
                _context.Messages.Add(message);
                _context.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void PutMessage(Message message) 
        {
            if (ModelState.IsValid)
            {
                _context.Messages.Update(message);
                _context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public async Task DeleteMessage(int id)
        {
            Message message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
            }

            await _context.SaveChangesAsync();
        }
    }
}
