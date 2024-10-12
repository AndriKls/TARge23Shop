using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using ShopTARge23.Models.RealEstates;

namespace ShopTARge23.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ShopTARge23Context _context;
        private readonly IRealEstateServices _realEstateServices;

        public RealEstatesController
            (
                ShopTARge23Context context,
                IRealEstateServices realEstateServices
            )
        {
            _context = context;
            _realEstateServices = realEstateServices;
        }

        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstatesIndexViewModel
                {
                    Id = x.Id,
                    Size = x.Size,
                    Location = x.Location,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstatesCreateUpdateViewModel realEstates = new();

            return View("CreateUpdate", realEstates);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstatesCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Size = vm.Size,
                Location = vm.Location,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new FileToDatabaseDto
                    {
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        RealEstateId = x.RealEstateId
                    }).ToArray()
            };

            var result = await _realEstateServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstatesDetailsViewModel();

            vm.Id = realEstate.Id;
            vm.Size = realEstate.Size;
            vm.Location = realEstate.Location;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstatesCreateUpdateViewModel();

            vm.Id = realEstate.Id;
            vm.Size = realEstate.Size;
            vm.Location = realEstate.Location;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstatesCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Size = vm.Size,
                Location = vm.Location,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _realEstateServices.Update(dto);

            if (result ==  null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstatesDeleteViewModel();

            vm.Id = realEstate.Id;
            vm.Size = realEstate.Size;
            vm.Location = realEstate.Location;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstate = await _realEstateServices.Delete(id);

            if (realEstate == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
