using Blog_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Blog_Application.Models;

namespace Blog_Application.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmailWithAttachment(EmailService model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Sender's email credentials
                    string senderEmail = "manuverma36891@gmail.com";
                    string senderPassword = "@Digjack18";

                    // Mail message
                    MailMessage mail = new MailMessage(senderEmail, model.RecipientEmail);
                    mail.Subject = "Email with Attachment";
                    mail.Body = "This email contains an attachment.";

                    // Attachment
                    if (model.Attachment != null && model.Attachment.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            model.Attachment.CopyTo(ms);
                            byte[] fileBytes = ms.ToArray();
                            mail.Attachments.Add(new Attachment(new MemoryStream(fileBytes), model.Attachment.FileName));
                        }
                    }

                    // SMTP client
                    SmtpClient client = new SmtpClient("smtp.example.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(senderEmail, senderPassword),
                        EnableSsl = true
                    };

                    // Send email
                    client.Send(mail);

                    ViewBag.Message = "Email sent successfully!";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"Error occurred: {ex.Message}";
                }
            }

            return View("Index");
        }
    }
}
