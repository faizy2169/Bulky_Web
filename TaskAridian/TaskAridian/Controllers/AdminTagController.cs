using Microsoft.AspNetCore.Mvc;
using TaskAridian.Data;
using TaskAridian.Models;

namespace TaskAridian.Controllers
{
    public class AdminTagController : Controller
    {
        private readonly AppDbContext appDb;

        public AdminTagController(AppDbContext appDb)
        {
            this.appDb = appDb;
        }
      [HttpGet]  
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Admin request)
        {
            var adminData = new Admin
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };
            appDb.Admins.Add(adminData);
            appDb.SaveChanges();
            //var email = request.Email;
            //var firstName = request.FirstName;
            //var lastName = request.LastName;

            return View("Add");
        }
    }
}
