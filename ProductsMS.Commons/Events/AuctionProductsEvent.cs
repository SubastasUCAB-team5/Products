using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Contracts.Events
{
    public class AuctionProductsEvent
    {
        public Guid AuctionId { get; set; }
        public List<string> Products { get; set; } = new List<string>();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
