using MassTransit;
using ProductMS.Domain.Entities;
using ProductMS.Infrastructure.DataBase;
using ProductMS.Commons.Events;

namespace ProductMS.Infrastructure.Messaging.Consumers;

public class ProductCreatedConsumer : IConsumer<ProductCreatedEvent>
{
    private readonly MongoDbContext _mongo;

    public ProductCreatedConsumer(MongoDbContext mongo)
    {
        _mongo = mongo;
    }

    public async Task Consume(ConsumeContext<ProductCreatedEvent> context)
    {
        var message = context.Message;

        var product = new ProductReadModel
        {
            Id = message.Id,
            Name = message.Name,
            Description = message.Description,
            BasePrice = message.BasePrice,
            Category = message.Category,
            Images = message.Images,
            State = message.State,
            CreatedAt = message.CreatedAt
        };

        await _mongo.Products.InsertOneAsync(product);


    }

}
