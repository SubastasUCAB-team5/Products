using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Commons.Dtos.Response;

namespace ProductMS.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductsDto>>
    {
        public GetAllProductsQuery() { }
    }
}

