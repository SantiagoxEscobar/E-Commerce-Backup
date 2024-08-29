using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class ServiceEmail
    {
        private MailMessage email;
        private SmtpClient server;

        public ServiceEmail()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("pruebalab3carrito@gmail.com", "yhny wpqf muvt iyiv");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
            

        }

        public void armarcorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("pruebalab3carrito@gmail.com");
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

                throw ex;
            }
        }
    }
}
