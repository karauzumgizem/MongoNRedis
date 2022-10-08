using FarmasiCase.Entities.Dto;
using FarmasiCase.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FarmasiCase.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _serv;

        public HomeController(IProductService serv)
        {
            _serv = serv;
        }
        public IActionResult Index()
        {
            var x = _serv.GetAll();
            return View(x);
        }
    }
}
