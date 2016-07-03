using Microsoft.AspNetCore.Mvc;

namespace Etherkeep.Server.Controllers.API
{ 
    public class DefaultController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
