using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Domain.Entities;

namespace ProductMS.Core.Service
{
    public interface IEventPublisher
    {
        Task PublishProductCreatedAsync(Product product);
        Task PublishProductUpdatedAsync(Product product);

    }
}
