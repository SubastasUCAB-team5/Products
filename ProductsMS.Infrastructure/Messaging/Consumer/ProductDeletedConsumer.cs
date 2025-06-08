using MassTransit;
using ProductMS.Domain.Entities;
using ProductMS.Infrastructure.DataBase;
using ProductMS.Commons.Events;
using MongoDB.Driver;

namespace ProductMS.Infrastructure.Messaging.Consumers;

public class ProductDeletedConsumer : IConsumer<ProductDeletedEvent>
{
    private readonly MongoDbContext _mongo;

    public ProductDeletedConsumer(MongoDbContext mongo)
    {
        _mongo = mongo;
    }

    public async Task Consume(ConsumeContext<ProductDeletedEvent> context)
    {
        var message = context.Message;
        var filter = Builders<ProductReadModel>.Filter.Eq(u => u.Id, message.Id);
        await _mongo.Products.DeleteOneAsync(filter);
    }
}
