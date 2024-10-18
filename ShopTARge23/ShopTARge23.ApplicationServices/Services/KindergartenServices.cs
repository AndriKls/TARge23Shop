using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTARge23.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopTARge23Context _context;
        private readonly IFileServices _fileServices;

        public KindergartenServices
        (
            ShopTARge23Context context,
            IFileServices fileServices
        )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new Kindergarten();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, kindergarten);

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> DetailAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            var existingKindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (existingKindergarten == null)
            {
                throw new Exception("Kindergarten not found");
            }

            existingKindergarten.GroupName = dto.GroupName;
            existingKindergarten.ChildrenCount = dto.ChildrenCount;
            existingKindergarten.KindergartenName = dto.KindergartenName;
            existingKindergarten.Teacher = dto.Teacher;
            existingKindergarten.UpdatedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, existingKindergarten);

            _context.Kindergartens.Update(existingKindergarten);
            await _context.SaveChangesAsync();

            return existingKindergarten;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToApis
                .Where(x => x.KindergartenId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    KindergartenId = y.KindergartenId,
                    ExistingFilePath = y.ExistingFilePath,
                }).ToArrayAsync();

            await _fileServices.RemoveImagesFromApi(images);
            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }
    }
}
