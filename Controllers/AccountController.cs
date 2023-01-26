using Microsoft.AspNetCore.Mvc;

namespace Nachweis0r.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}