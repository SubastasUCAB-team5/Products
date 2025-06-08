using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using ProductMS.Domain.Entities;
using ProductMS.Commons.Events;
using ProductMS.Core.Service;

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
                CreatedAt = product.CreatedAt
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
                CreatedAt = product.UpdatedAt ?? product.CreatedAt
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
                CreatedAt = DateTime.UtcNow
            };

            await _publishEndpoint.Publish(@event);
        }
    }
}

