using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMS.Commons.Dtos.Request
{
    public record DeleteProductDto
    {
        public Guid ProductId { get; set; }
    }
}
