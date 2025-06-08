using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Commons.Dtos.Response;
using MediatR;

namespace ProductMS.Application.Queries
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public Guid ProductId { get; set; }

        public GetProductQuery() { }

        public GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
