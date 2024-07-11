using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Blog_Application.Models
{

    public class EmailService
    {
        public string RecipientEmail { get; set; }
        public IFormFile Attachment { get; set; }
    }

}

