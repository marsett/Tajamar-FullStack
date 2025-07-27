﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace MvcNetCoreUtilidades.Controllers
{
    public class MailsController : Controller
    {
        // Necesitamos el fichero de configuration
        private IConfiguration configuration;
        public MailsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string to, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();
            // Debemos indicar el from, es decir, de qué cuenta viene
            // el correo (la nuestra de appsettings.json)
            string user = this.configuration.GetValue<string>("MailSettings:Credentials:User");
            mail.From = new MailAddress(user);
            // Los destinatarios son una colección
            mail.To.Add(to);
            mail.Subject = asunto;
            mail.Body = mensaje;
            //<h1>Hola</h1>
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            string password = this.configuration.GetValue<string>("MailSettings:Credentials:Password");
            string host = this.configuration.GetValue<string>("MailSettings:Server:Host");
            int port = this.configuration.GetValue<int>("MailSettings:Server:Port");
            bool ssl = this.configuration.GetValue<bool>("MailSettings:Server:Ssl");
            bool defaultCredentials = this.configuration.GetValue<bool>("MailSettings:Server:DefaultCredentials");
            // Creamos la clase servidor SMTP
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
            smtpClient.UseDefaultCredentials = defaultCredentials;
            // Creamos las credenciales para el mail
            NetworkCredential credentials = new NetworkCredential(user, password);
            smtpClient.Credentials = credentials;
            await smtpClient.SendMailAsync(mail);
            ViewData["MENSAJE"] = "Mail enviado correctamente??";
            return View();
        }
    }
}
