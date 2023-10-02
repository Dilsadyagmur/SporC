using Microsoft.AspNetCore.Mvc;
using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;

namespace SporC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> _repository) 
        {
            this._repository = _repository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            User user = _repository.GetAll();

        }

    }
}
