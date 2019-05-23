using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDocument.Models
{
    public partial class Status
    {
        public Status()
        {
            DocumentStatus = new HashSet<DocumentStatus>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<DocumentStatus> DocumentStatus { get; set; }
    }
}
