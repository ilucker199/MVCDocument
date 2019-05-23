using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDocument.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public ICollection<DocumentStatus> DocumentStatus { get; set; }
    }
}
