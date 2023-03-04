
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Localization.Models;

namespace Localization.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new User());
        }


        public IActionResult ChangeLang() 
        {
            Response.Cookies.Append(
                 CookieRequestCultureProvider.DefaultCookieName,
                 CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("ar")),
                 new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(60) }
             );
            return View("Index");
        }
    }
}
