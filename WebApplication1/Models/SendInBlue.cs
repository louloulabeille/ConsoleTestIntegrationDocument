using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Net;

namespace WebApplication1.Models
{
    public class SendInBlue : IEmailSender
    {
        private SmtpClient _smtpClient = null;
        private MailMessage _mail;
        public SendInBlue()
        {
            _mail = new MailMessage();
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                _mail.Body = htmlMessage;
                _mail.From = new MailAddress("louloulabeille@hotmail.com");
                _mail.To.Add(email);
                _mail.Subject = subject;
                _smtpClient = new SmtpClient("smtp-relay.sendinblue.com");
                _smtpClient.Port = 587;
                _smtpClient.Credentials = new NetworkCredential("louloulabeille@hotmail.com", "6XCT23d1jrAyYMBH");
                _smtpClient.EnableSsl = true;
                await Task.Run(() => _smtpClient.Send(_mail));
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
