using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;


namespace ShopTARge23.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly ShopTARge23Context _context;
        private readonly IFileServices _fileServices;

        public SpaceshipsServices
            (
                ShopTARge23Context context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Typename = dto.Typename;
            spaceship.SpaceshipModel = dto.SpaceshipModel;
            spaceship.BuiltDate = dto.BuiltDate;
            spaceship.Crew = dto.Crew;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, spaceship);

            await _context.Spaceships.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }


        public async Task<Spaceship> DetailAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync( x => x.Id == id );

            return result;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship domain = new();

            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.Typename = dto.Typename;
            domain.SpaceshipModel = dto.SpaceshipModel;
            domain.BuiltDate = dto.BuiltDate;
            domain.Crew = dto.Crew;
            domain.EnginePower = dto.EnginePower;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, domain);

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceship = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToApis
                .Where(x => x.SpaceshipId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    SpaceshipId = y.SpaceshipId,
                    ExistingFilePath = y.ExistingFilePath,
                }).ToArrayAsync();

            await _fileServices.RemoveImagesFromApi(images);
            _context.Spaceships.Remove(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

    }
}
