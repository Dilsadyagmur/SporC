using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;
using SporC.Web.Models;

namespace SporC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository) 
        {
            repository = _repository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Login(LoginViewModel model)
        {
            // _repository servisini kullanarak kullanıcı adına ve şifreye göre bir kullanıcı bulun
            User appuser = (await _repository.GetAllInclude(u => u.UserName == model.UserName && u.Password == model.Password)).Include(u => u.UserType).First();
            
    }

}
}
