using System;
using System.Collections.Generic;
using ProductMS.Domain.Entities;

namespace ProductMS.Commons.Events
{
    public class ProductUpdatedEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string BasePrice { get; set; } = default!;
        public string Category { get; set; } = default!;
        public List<string> Images { get; set; } = new List<string>();
        public ProductState State { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
