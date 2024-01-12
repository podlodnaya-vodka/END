using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END.Domain.Entities
{
    public class AttributeTypeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public DocumentTypeEntity Type { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}
