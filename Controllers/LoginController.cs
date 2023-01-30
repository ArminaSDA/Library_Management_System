using Library_Management_System.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Library_Management_System.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginRepository _loginUser;
        public LoginController(ILogger<LoginController> logger, ILoginRepository loginUser)
        {
            _logger = logger;
            _loginUser = loginUser;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string username, string passcode)
        {
            var issuccess = _loginUser.AuthenticateUser(username, passcode);


            if (issuccess.Result != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);
                return View();

            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return View();
            }
        }


    }
}