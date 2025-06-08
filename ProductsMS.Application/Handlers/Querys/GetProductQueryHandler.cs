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
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
                throw new ProductNotFoundException("Product not found.");

            return new GetProductDto
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
            };
        }
    }
}

