using MediatR;
using ProductMS.Application.Commands;
using ProductMS.Core.Repositories;
using ProductMS.Core.Service;

namespace ProductMS.Application.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventPublisher _eventPublisher;

        public DeleteProductCommandHandler(IProductRepository productRepository, IEventPublisher eventPublisher)
        {
            _productRepository = productRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productId = request.DeleteProductDto.ProductId;

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new ApplicationException($"No product found with ID {productId}");

            if (string.IsNullOrEmpty(product.Name))
                throw new ApplicationException("Product email cannot be null or empty.");

            await _productRepository.DeleteAsync(productId);
            await _eventPublisher.PublishProductDeletedAsync(product);
            return "Product successfully disabled.";
        }
    }
}

