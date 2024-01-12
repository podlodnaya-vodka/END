using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END.Application.DTO
{
    public class DocumentLinkDto
    {
        public Guid ParentDocumentId { get; set; }
        public Guid ChildDocumentId { get; set; }
    }
}
