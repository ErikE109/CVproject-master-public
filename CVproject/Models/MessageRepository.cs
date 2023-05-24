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
using NuGet.Protocol.Core.Types;

namespace CVproject.Models
{
    public class MessageRepository
    {
       
        private HttpClient _httpClient;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageRepository( HttpClient httpClient,  IHttpContextAccessor httpContextAccessor) 
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Message>> GetAllMessages()
        {
             try { 
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                HttpResponseMessage response = await _httpClient.GetAsync($"message/{userId}");
                string data = await response.Content.ReadAsStringAsync();
                var opstions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                List<Message> messageList = JsonSerializer.Deserialize<List<Message>>(data, opstions).ToList();

                return messageList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }
            return new List<Message>();
}


        public async Task<int> GetAllUnreadMessages() 
        {
            
            var userMessages = await GetAllMessages();
            int total = 0;

            foreach (var message in userMessages)
            {
                if(!message.IsRead)
                {
                    total++;
                }
            }

            return total;
        }
    }
}
