using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Application.Queries;
using ProductMS.Commons.Dtos.Response;
using ProductMS.Core.Repositories;
using ProductMS.Infrastructure.Exceptions;

namespace ProductMS.Application.Handlers.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetAllProductsDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            if (products == null) throw new ProductNotFoundException("Products not found.");

            return products.Select(product => new GetAllProductsDto
            {
                ProductId = product.Id!,
                Name = product.Name!,
                Description = product.Description!,
                BasePrice = product.BasePrice.ToString(),
                Category = product.Category!,
                Images = product.Images,
                State = product.State,
                CreatedAt = product.CreatedAt,
                CreatedBy = "system"
            }).ToList();
        }
    }
}

