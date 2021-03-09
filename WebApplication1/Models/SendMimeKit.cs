using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using MimeKit;
using MailKit.Net.Smtp;

namespace WebApplication1.Models
{
    public class SendMimeKit : IEmailSender
    {
        private readonly IEmailConfiguration _emailConfiguration = null;
        public SendMimeKit(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        /// <summary>
        /// methode d'envoie de mail
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                if ( _emailConfiguration == null )
                {
                    throw new ApplicationException("le système d'envoie des mails n'a pas été configuré.");
                }
                var message = new MimeMessage();
                var bodyBuilder = new BodyBuilder();

                MailboxAddress to = MailboxAddress.Parse(_emailConfiguration.SmtpUsername);
                message.To.Add(to);
                MailboxAddress from = MailboxAddress.Parse(email);
                message.From.Add(from);
                bodyBuilder.HtmlBody = htmlMessage;
                message.Body = bodyBuilder.ToMessageBody();
                message.Subject = subject;

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                    await Task.Run(()=> client.Send(message));
                    client.Disconnect(true);
                }
                
            }
            catch (SmtpCommandException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch ( Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
