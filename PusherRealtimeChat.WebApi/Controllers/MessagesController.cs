using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using PusherRealtimeChat.WebApi.Models;
using PusherServer;

namespace PusherRealtimeChat.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MessagesController : ApiController
    {
        private static readonly List<ChatMessage> Messages =
            new List<ChatMessage>()
            {
                new ChatMessage
                {
                    AuthorTwitterHandle = "Pusher",
                    Text = "Hi there! ?"
                },
                new ChatMessage
                {
                    AuthorTwitterHandle = "Pusher",
                    Text = "Welcome to your chat app"
                }
            };

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                Messages);
        }

        public async Task<HttpResponseMessage> Post(ChatMessage message)
        {
            if (message == null || !ModelState.IsValid)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    "Invalid input");
            }
            Messages.Add(message);

            var options = new PusherOptions
            {
                Cluster = "us2",
                Encrypted = true
            };

            var pusher = new Pusher(
                "353773",
                "c088abb9b16db88a216c",
                "1aca6ec11d25614f7e71",
                options);

            var result = await pusher.TriggerAsync(
                "my-channel",
                "my-event",
                new { message = "hello world" });

    

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}