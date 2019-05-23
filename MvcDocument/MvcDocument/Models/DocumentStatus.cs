using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDocument.Models
{
    public partial class DocumentStatus
    {
        public int DocumentStatusId { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime DateTime { get; set; }
    }
}