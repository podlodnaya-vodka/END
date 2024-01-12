using END.Application.DTO;
using END.Application.Interfaces.Services;
using END.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace END.Persistence.Services
{
    public class DocumentService : IDocumentService
    {
        EntityDBContext _context;
        public DocumentService(EntityDBContext context)
        {
            _context = context;
        }

        public async ValueTask<IList<DocumentEntity>> GetAllAsync()
        {
            return await _context.Documents.Include(x => x.Type)
                                           .Include(x => x.ParentDocuments)
                                           .Include(x => x.ChildDocuments)
                                           .Include(x => x.Attributes)
                                           .ThenInclude(x => x.Attribute)
                                           .ToListAsync();
        }

        public async ValueTask<DocumentEntity> GetByIdAsync(Guid id)
        {
            return await _context.Documents.Include(x => x.Type)
                                           .Include(x => x.ParentDocuments)
                                           .Include(x => x.ChildDocuments)
                                           .Include(x => x.Attributes)
                                           .ThenInclude(x => x.Attribute)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var del = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);
            if (del is null)
                return false;

            _context.Documents.Remove(del);
            await _context.SaveChangesAsync();
            return true;
        }

        public async ValueTask<bool> CreateAsync(DocumentDto dto)
        {
            var type = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Name == dto.Type);
            if (type is null)
                return false;
            var doc = new DocumentEntity()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                TypeId = type.Id
            };
            await _context.Documents.AddAsync(doc);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, DocumentDto dto)
        {
            var type = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Name == dto.Type);
            if(type is null)
                return false;
            var doc = new DocumentEntity()
            {
                Id = id,
                Name = dto.Name,
                TypeId = type.Id
            };
            await Task.Run(() => _context.Documents.Update(doc));
            return _context.SaveChanges() > 0;
        }
    }
}




//foreach (var attr in dto.Attributes)
//{
//    var attribute = await _context.AttributeTypes.FirstOrDefaultAsync(x => x.Id == attr.AttributeId);
//    var docAttr = new AttributeValueEntity()
//    {
//        Id = Guid.NewGuid(),
//        Document = doc,
//        Attribute = attribute,
//        Value = attr.Value
//    };
//    await _context.AttributeValues.AddAsync(docAttr);
//}

//foreach (var attr in dto.Attributes)
//{
//    var attribute = await _context.AttributeTypes.FirstOrDefaultAsync(x => x.Id == attr.AttributeId);

//    Guid id;
//    var value = await _context.AttributeValues.FirstOrDefaultAsync(x => x.Id == attr.Id);
//    if (value is null)
//        id = Guid.NewGuid();
//    else
//        id = attr.Id;

//    var docAttr = new AttributeValueEntity()
//    {
//        Id = id,
//        Document = doc,
//        Attribute = attribute,
//        Value = attr.Value
//    };

//    await _context.AttributeValues.AddAsync(docAttr);
//}