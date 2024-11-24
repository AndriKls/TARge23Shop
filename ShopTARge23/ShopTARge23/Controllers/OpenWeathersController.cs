using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.OpenWeathers;

namespace ShopTARge23.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeathersServices _openWeathersServices;

        public OpenWeathersController(IOpenWeathersServices openWeathersServices)
        {
            _openWeathersServices = openWeathersServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeathers", new { city = model.City });
            }
            return View(model);
        }

        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new();
            dto.City = city;
            _openWeathersServices.OpenWeatherResult(dto);
            OpenWeathersViewModel vm = new();

            vm.City = dto.City;
            vm.Temp = dto.Temp;
            vm.FeelsLike = dto.FeelsLike;
            vm.Humidity = dto.Humidity;
            vm.Pressure = dto.Pressure;
            vm.WindSpeed = dto.WindSpeed;
            vm.Conditions = dto.Conditions;
            vm.Icon = dto.Icon;

            return View(vm);
        }
    }
}
