using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END.Domain.Entities
{
    public class DocumentLinkEntity
    {
        [Key]
        public Guid Id {  get; set; }
        public Guid ParentDocumentId { get; set; }
        public Guid ChildDocumentId { get; set; }
    }
}
