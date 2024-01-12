using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END.Domain.Entities
{
    public class DocumentTypeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<AttributeTypeEntity> Attributes { get; set; }
    }
}
