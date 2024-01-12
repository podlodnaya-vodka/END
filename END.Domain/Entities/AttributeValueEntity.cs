using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END.Domain.Entities
{
    public class AttributeValueEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public DocumentEntity Document { get; set; }
        public Guid AttributeId { get; set; }
        public AttributeTypeEntity Attribute { get; set; }
        public string Value { get; set; }
    }
}
