using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProductMS.Application.Commands;
using ProductMS.Core.Repositories;
using ProductMS.Core.Service;
using ProductMS.Domain.Entities;
using ProductMS.Infrastructure.Service;

namespace ProductMS.Application.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventPublisher _eventPublisher;

        public CreateProductCommandHandler(IProductRepository productRepository, IEventPublisher eventPublisher)
        {
            _productRepository = productRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateProductDto;

            var product = new Product(
                dto.Name!,
                dto.Description!,
                dto.BasePrice,
                dto.Category!,
                dto.Images,
                dto.State
            )
            {
                State = dto.State
            };

            await _productRepository.AddAsync(product);
            await _eventPublisher.PublishProductCreatedAsync(product);


            return "Product successfully created.";
        }
    }
}
