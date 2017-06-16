using System.ComponentModel.DataAnnotations;

namespace PusherRealtimeChat.WebApi.Models
{
    public class ChatMessage
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string AuthorTwitterHandle { get; set; }
    }
}