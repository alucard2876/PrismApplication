using Domain.Entities;
using Prism.Events;

namespace Buisness.Events
{
    public class ProductAddedEvent : PubSubEvent<Product>
    {
    }
}
