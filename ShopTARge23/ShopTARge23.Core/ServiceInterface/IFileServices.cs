using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
        void FilesToApi(KindergartenDto dto, Kindergarten kindergarten);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);
    }
}
