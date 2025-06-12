using System.Threading.Tasks;
using MassTransit;
using Contracts.Events;
using System.Text.Json;
using ProductMS.Core.Repositories;
using ProductMS.Domain.Entities;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ProductMS.Infrastructure.Messaging.Consumers
{
    public class AuctionProductsConsumer : IConsumer<AuctionProductsEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<AuctionProductsConsumer> _logger;

        public AuctionProductsConsumer(IProductRepository productRepository, ILogger<AuctionProductsConsumer> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<AuctionProductsEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation("[AuctionProductsConsumer] Processing event for auction {AuctionId} with {ProductCount} products", 
                message.AuctionId, message.Products?.Count ?? 0);

            try
            {
                if (message.Products == null || !message.Products.Any())
                {
                    _logger.LogWarning("[AuctionProductsConsumer] No products found in the event for auction {AuctionId}", message.AuctionId);
                    return;
                }

                _logger.LogInformation("[AuctionProductsConsumer] Updating {ProductCount} products to InAuction state", message.Products.Count);
                await _productRepository.UpdateProductsStateAsync(message.Products, ProductState.InAuction);
                
                _logger.LogInformation("[AuctionProductsConsumer] Successfully updated {ProductCount} products to InAuction state for auction {AuctionId}", 
                    message.Products.Count, message.AuctionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[AuctionProductsConsumer] Error processing auction products for auction {AuctionId}", message.AuctionId);
                throw; 
            }
        }
    }
}


