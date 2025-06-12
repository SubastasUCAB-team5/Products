using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using ProductMS.Domain.Entities;
using ProductMS.Commons.Events;
using ProductMS.Core.Service;
using Contracts.Events;

namespace ProductMS.Infrastructure.Service
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishProductCreatedAsync(Product product)
        {
            var @event = new ProductCreatedEvent
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                Category = product.Category,
                Images = product.Images,
                State = product.State,
                CreatedAt = product.CreatedAt,
                UserId = product.UserId
            };

            await _publishEndpoint.Publish(@event);
        }
        public async Task PublishProductUpdatedAsync(Product product)
        {
            var @event = new ProductUpdatedEvent
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                Category = product.Category,
                Images = product.Images,
                State = product.State,
                CreatedAt = product.UpdatedAt ?? product.CreatedAt,
                UserId = product.UserId
            };

            await _publishEndpoint.Publish(@event);
        }
        public async Task PublishProductDeletedAsync(Product product)
        {
            var @event = new ProductDeletedEvent
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                Category = product.Category,
                Images = product.Images,
                CreatedAt = DateTime.UtcNow,
                UserId = product.UserId
            };

            await _publishEndpoint.Publish(@event);
        }
        public async Task PublishAuctionProductsAsync(AuctionProductsEvent auctionProductsEvent)
        {
            Console.WriteLine($"[PublishAuctionProductsAsync] Publicando evento AuctionProductsEvent para AuctionId: {auctionProductsEvent.AuctionId} con {auctionProductsEvent.Products?.Count ?? 0} productos. Timestamp: {auctionProductsEvent.Timestamp}");
            await _publishEndpoint.Publish(auctionProductsEvent);
            Console.WriteLine($"[PublishAuctionProductsAsync] Evento AuctionProductsEvent publicado para AuctionId: {auctionProductsEvent.AuctionId}");
        }
    }
}

