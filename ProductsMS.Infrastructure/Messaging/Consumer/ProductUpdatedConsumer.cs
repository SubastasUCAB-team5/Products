using MassTransit;
using ProductMS.Domain.Entities;
using ProductMS.Infrastructure.DataBase;
using ProductMS.Commons.Events;
using MongoDB.Driver;

namespace ProductMS.Infrastructure.Messaging.Consumers;

public class ProductUpdatedConsumer : IConsumer<ProductUpdatedEvent>
{
    private readonly MongoDbContext _mongo;

    public ProductUpdatedConsumer(MongoDbContext mongo)
    {
        _mongo = mongo;
    }

    public async Task Consume(ConsumeContext<ProductUpdatedEvent> context)
    {
        var message = context.Message;

        var filter = Builders<ProductReadModel>.Filter.Eq(u => u.Id, message.Id);
        var update = Builders<ProductReadModel>.Update
            .Set(u => u.Name, message.Name)
            .Set(u => u.Description, message.Description)
            .Set(u => u.BasePrice, message.BasePrice)
            .Set(u => u.Category, message.Category)
            .Set(u => u.Images, message.Images)
            .Set(u => u.State, message.State)
            .Set(u => u.CreatedAt, message.CreatedAt);


        await _mongo.Products.UpdateOneAsync(filter, update);
    }
}
