using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Domain.Entities;

namespace ProductMS.Commons.Dtos.Response
{
    public record GetProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string BasePrice { get; set; } = default!;
        public string Category { get; set; } = default!;
        public List<string> Images { get; set; } = new List<string>();
        public ProductState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
