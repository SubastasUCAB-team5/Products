using MediatR;
using ProductMS.Application.Commands;
using ProductMS.Core.Repositories;
using ProductMS.Infrastructure.Exceptions;
using ProductMS.Core.Service;

namespace ProductMS.Application.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventPublisher _eventPublisher;

        public UpdateProductCommandHandler(IProductRepository productRepository, IEventPublisher eventPublisher)
        {
            _productRepository = productRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.UpdateProductDto.ProductId!);
            if (product == null)
                throw new ProductNotFoundException("Product not found.");

            if (!string.IsNullOrEmpty(request.UpdateProductDto.Name)) product.Name = request.UpdateProductDto.Name;
            if (!string.IsNullOrEmpty(request.UpdateProductDto.Description)) product.Description = request.UpdateProductDto.Description;
            if (!string.IsNullOrEmpty(request.UpdateProductDto.BasePrice)) product.BasePrice = request.UpdateProductDto.BasePrice; 
            if (!string.IsNullOrEmpty(request.UpdateProductDto.Category)) product.Category = request.UpdateProductDto.Category;
            if (request.UpdateProductDto.Images?.Count > 0) product.Images = request.UpdateProductDto.Images;
            if (request.UpdateProductDto.State.HasValue) product.State = request.UpdateProductDto.State.Value;

            await _productRepository.UpdateAsync(product);
            await _eventPublisher.PublishProductUpdatedAsync(product);
            return "Product updated successfully.";
        }
    }
}

