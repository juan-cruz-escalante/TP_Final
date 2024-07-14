﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("c6dffa9ab9857b", "5c1043090d0ec0");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";

            email = new MailMessage();
            email.From = new MailAddress("noresponder@programaciontres.com");
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar correo electrónico.", ex);
            }
        }
    }
}
