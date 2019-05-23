using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcDocument.Models
{
    public class MvcDocumentContext : DbContext
    {
        public MvcDocumentContext (DbContextOptions<MvcDocumentContext> options)
            : base(options)
        {
        }

        public DbSet<MvcDocument.Models.Document> Document { get; set; }
        public DbSet<MvcDocument.Models.Document> DocumentStatus { get; set; }
        public DbSet<MvcDocument.Models.Document> Status { get; set; }
    }
}
