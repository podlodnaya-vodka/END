using END.Application.DTO;
using END.Application.Interfaces.Services;
using END.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace END.Persistence.Services
{
    public class DocumentLinkService : IDocumentLinkService
    {
        EntityDBContext _context;
        public DocumentLinkService(EntityDBContext context)
        {
            _context = context;
        }
        public async ValueTask<IList<DocumentLinkEntity>> GetAllAsync()
        {
            return await _context.DocumentLinks.ToListAsync();
        }

        public async ValueTask<DocumentLinkEntity> GetByIdAsync(Guid id)
        {
            return await _context.DocumentLinks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var del = await _context.DocumentLinks.FirstOrDefaultAsync(x => x.Id == id);
            if (del is null)
                return false;

            _context.DocumentLinks.Remove(del);
            await _context.SaveChangesAsync();
            return true;
        }

        public async ValueTask<bool> CreateAsync(DocumentLinkDto dto)
        {
            var parantDoc = await _context.Documents.FirstOrDefaultAsync(x => x.Id == dto.ParentDocumentId);
            var chikdDoc = await _context.Documents.FirstOrDefaultAsync(x => x.Id == dto.ChildDocumentId);
            if (parantDoc is null && chikdDoc is null)
                return false;
            DocumentLinkEntity entity = new DocumentLinkEntity
            {
                Id = Guid.NewGuid(),
                ParentDocumentId = dto.ParentDocumentId,
                ChildDocumentId = dto.ChildDocumentId,
            };
            await _context.DocumentLinks.AddAsync(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, DocumentLinkDto dto)
        {
            var parantDoc = await _context.Documents.FirstOrDefaultAsync(x => x.Id == dto.ParentDocumentId);
            var chikdDoc = await _context.Documents.FirstOrDefaultAsync(x => x.Id == dto.ChildDocumentId);
            if (parantDoc is null && chikdDoc is null)
                return false;
            DocumentLinkEntity entity = new DocumentLinkEntity
            {
                Id = id,
                ParentDocumentId = dto.ParentDocumentId,
                ChildDocumentId = dto.ChildDocumentId,
            };
            await _context.DocumentLinks.AddAsync(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
