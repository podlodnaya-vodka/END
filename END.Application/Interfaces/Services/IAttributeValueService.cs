using END.Application.DTO;
using END.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END.Application.Interfaces.Services
{
    public interface IAttributeValueService
    {
        public ValueTask<AttributeValueEntity> GetByIdAsync(Guid id);
        public ValueTask<IList<AttributeValueEntity>> GetAllAsync();
        public ValueTask<bool> DeleteAsync(Guid id);
        public ValueTask<bool> CreateAsync(AttributeValueDto dto);
        public Task<bool> UpdateAsync(Guid id, AttributeValueDto dto);
    }
}
