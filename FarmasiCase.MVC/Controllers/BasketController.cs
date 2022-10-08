using FarmasiCase.Entities.Dto;
using FarmasiCase.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FarmasiCase.MVC.Controllers
{
    public class BasketController : Controller
    {

        private readonly IBasketService _serv;

        public BasketController(IBasketService serv)
        {
            _serv = serv;
        }

        public JsonResult AddBasket(BasketDto model)
        {
            var x = _serv.UpdateBasket(model);
           
            return Json(1);
        }


        public  IActionResult GetAll()
        {
            var model =  _serv.GetBasket("prod");
            return View(model);
        }

        public JsonResult DeleteBasket(BasketDto model)
        {
            var x = _serv.DeleteBasket(model);

            return Json(1);
        }
    }
}
