using Microsoft.AspNetCore.Http;
using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.DAL.Repositories.Concrete;
using SporC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SporC.BL.Concrete
{
    public class UserManager : ManagerBase<User>, IUserManager
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IRepository<User> repository, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _userRepository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> FindByEmailOrUsernameAsync(string emailOrUsername)
        {
            return  _userRepository.GetFirstOrDefault(u => u.Email == emailOrUsername || u.UserName == emailOrUsername);
        }

       

        public async  Task<int> GetCurrentUserIdAsync()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await Task.FromResult(userId);
        }

        public static bool SendMail(string mailtol)
        {
            try
            {

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp-relay.brevo.com";
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("dilsadygmur@gmail.com", " CT075VPAFSyKLjOt"); 
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dilsadygmur@gmail.com", "test");
                mail.To.Add(mailtol);
                mail.Subject = "test"; mail.IsBodyHtml = true; mail.Body = "şifre sıfırlama cart vutr";
                sc.Send(mail);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<User> GetUserById()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

           var user=  await _userRepository.GetById(userId);

           
            return user;
        }
    }
}
