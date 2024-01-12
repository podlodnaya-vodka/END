using END.Application.DTO;
using END.Domain.Entities;

namespace END.Application.Interfaces.Services
{
    public interface IDocumentService
    {
        public ValueTask<DocumentEntity> GetByIdAsync(Guid id);
        public ValueTask<IList<DocumentEntity>> GetAllAsync();
        public ValueTask<bool> DeleteAsync(Guid id);
        public ValueTask<bool> CreateAsync(DocumentDto dto);
        public Task<bool> UpdateAsync(Guid id, DocumentDto dto);
    }
}
