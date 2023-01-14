using AlbumApplication.Data.Classes;
using AlbumApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlbumApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Admin _admin;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, Admin admin, ApplicationDbContext db)
        {
            _logger = logger;
            _admin = admin;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AdminViewModel adminViewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.Password = Cryptograph.Cryptography(adminViewModel.Password);
                _admin.Username = adminViewModel.Username;
                _db.Admins.Add(_admin);
                _db.SaveChanges();
                //After registration go to Login Page
                return View("Login");
            }
            return View("Index");
        }

        public IActionResult Login(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var administrator = _db.Admins.FirstOrDefault(y=>y.Username==admin.Username);
            if (administrator == null || Cryptograph.Cryptography( admin.Password) != Cryptograph.Cryptography(admin.Password))
            {
                ViewBag.Situtation = "Username Or Password Is Wrong";
                return View();
            }
            return RedirectToAction("Index", "Album");


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}