using MediatR;
using ProductMS.Application.Commands;
using ProductMS.Core.Repositories;
using ProductMS.Domain.Exceptions;
using ProductMS.Infrastructure.Exceptions;

namespace ProductMS.Application.Handlers.Commands
{
    public class ChangeProductStateCommandHandler : IRequestHandler<ChangeProductStateCommand, string>
    {
        private readonly IProductRepository _productRepository;

        public ChangeProductStateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> Handle(ChangeProductStateCommand request, CancellationToken cancellationToken)
        {
            var dto = request.ChangeProductStateDto;
            var product = await _productRepository.GetByIdAsync(dto.ProductId);

            if (product == null)
            {
                throw new ProductNotFoundException($"No se encontró el producto con ID {dto.ProductId}");
            }

            try
            {
                product.ChangeState(dto.NewState);
                product.UpdatedAt = DateTime.UtcNow; 
                await _productRepository.UpdateAsync(product);
                
                return $"Estado del producto actualizado correctamente a {dto.NewState}";
            }
            catch (InvalidProductStateTransitionException ex)
            {
                throw new InvalidOperationException($"No se puede cambiar el estado del producto: {ex.Message}", ex);
            }
            catch (Exception)
            {
                // Log the exception
                throw new Exception("Ocurrió un error al intentar cambiar el estado del producto");
            }
        }
    }
}
