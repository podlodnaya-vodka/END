using END.Application.DTO;
using END.Application.Interfaces.Services;
using END.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace END.Persistence.Services
{
    public class AttributeValueService : IAttributeValueService
    {
        EntityDBContext _context;
        public AttributeValueService(EntityDBContext context)
        {
            _context = context;
        }

        public async ValueTask<IList<AttributeValueEntity>> GetAllAsync()
        {
            return await _context.AttributeValues.ToListAsync();
        }

        public async ValueTask<AttributeValueEntity> GetByIdAsync(Guid id)
        {
            return await _context.AttributeValues.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var del = await _context.AttributeValues.FirstOrDefaultAsync(x => x.Id == id);
            if (del is null)
                return false;

            _context.AttributeValues.Remove(del);
            await _context.SaveChangesAsync();
            return true;
        }


        public async ValueTask<bool> CreateAsync(AttributeValueDto dto)
        {
            var doc = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == dto.DocumentId);
            if (!(doc is null))
                return false;
            AttributeValueEntity entity = new AttributeValueEntity
            {
                Id = Guid.NewGuid(),
                DocumentId = dto.DocumentId,
                AttributeId = dto.AttributeId,
                Value = dto.Value
            };
            await _context.AttributeValues.AddAsync(entity);
            return _context.SaveChanges() > 0;
        }

        
        public async Task<bool> UpdateAsync(Guid id, AttributeValueDto dto)
        {
            var doc = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == dto.DocumentId);
            if (!(doc is null))
                return false;
            AttributeValueEntity entity = new AttributeValueEntity
            {
                Id = id,
                DocumentId = dto.DocumentId,
                AttributeId = dto.AttributeId,
                Value = dto.Value
            };
            await _context.AttributeValues.AddAsync(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
