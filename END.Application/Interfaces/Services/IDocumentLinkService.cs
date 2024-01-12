using END.Application.DTO;
using END.Domain.Entities;

namespace END.Application.Interfaces.Services
{
    public interface IDocumentLinkService
    {
        public ValueTask<DocumentLinkEntity> GetByIdAsync(Guid id);
        public ValueTask<IList<DocumentLinkEntity>> GetAllAsync();
        public ValueTask<bool> DeleteAsync(Guid id);
        public ValueTask<bool> CreateAsync(DocumentLinkDto dto);
        public Task<bool> UpdateAsync(Guid id, DocumentLinkDto dto);
    }
}
