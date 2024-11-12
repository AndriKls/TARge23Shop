using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Models.ChuckNorris;
using ShopTARge23.Core.Dto.ChuckNorrisRootDto;
using ShopTARge23.Core.ServiceInterface;


namespace ShopTARge23.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController
            (
                IChuckNorrisServices chuckNorrisServices
            )
        {
            _chuckNorrisServices = chuckNorrisServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchChuckNorrisJokes(ChuckNorrisViewModel model)
        {
            return RedirectToAction(nameof(Joke));
        }

        [HttpGet]
        public IActionResult Joke()
        {
            ChuckNorrisResultDto dto = new();

            _chuckNorrisServices.ChuckNorrisResult(dto);
            ChuckNorrisViewModel vm = new();

            vm.Categories = dto.Categories;
            vm.CreatedAt = dto.CreatedAt;
            vm.IconUrl = dto.IconUrl;
            vm.Id = dto.Id;
            vm.UpdatedAt = dto.UpdatedAt;
            vm.Url = dto.Url;
            vm.Value = dto.Value;

            return View(vm);
        }
    }
}
