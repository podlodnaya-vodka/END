using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace END.Domain.Entities
{
    public class DocumentEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DocumentTypeEntity Type { get; set; }
        public ICollection<AttributeValueEntity> Attributes { get; set; }
        public ICollection<DocumentLinkEntity> ParentDocuments { get; set; }
        public ICollection<DocumentLinkEntity> ChildDocuments { get; set; }
    }
}
