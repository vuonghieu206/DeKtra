using Microsoft.AspNetCore.Mvc;
using VuongTrungHieu_241230729.Models;

namespace VuongTrungHieu_241230729.Controllers;

public class HomeController : Controller
{
    public IActionResult Error() => View(new ErrorViewModel
    {
        RequestId = HttpContext.TraceIdentifier
    });
}
