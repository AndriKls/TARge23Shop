using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge23.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopTARge23Context _context;

        public KindergartenServices
        (
                ShopTARge23Context context
            )
        {
            _context = context;
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

            _context.Kindergartens.Update(existingKindergarten);
            await _context.SaveChangesAsync();

            return existingKindergarten;
        }


        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);


            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

    }
}
