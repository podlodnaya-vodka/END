using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END.Application.DTO
{
    public class AttributeValueDto
    {
        public Guid DocumentId { get; set; }
        public Guid AttributeId { get; set; }
        public string Name { get; set; } // для лога
        public string Value { get; set; }
    }
}
