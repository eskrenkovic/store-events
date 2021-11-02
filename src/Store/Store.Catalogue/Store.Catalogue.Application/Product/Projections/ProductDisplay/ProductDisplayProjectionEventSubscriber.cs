using System;
using System.Linq;
using System.Threading.Tasks;
using Store.Catalogue.Domain.Product.Events;
using Store.Catalogue.Infrastructure.Entity;
using Store.Core.Domain.Event;
using Store.Core.Domain.Projection;

namespace Store.Catalogue.Application.Product.Projections.ProductDisplay
{
    public class ProductDisplayProjectionEventSubscriber : IEventSubscriber
    {
        private readonly Type[] _supportedTypes =
        {
            typeof(ProductCreatedEvent),
            typeof(ProductPriceChangedEvent),
            typeof(ProductRatedEvent),
            typeof(ProductTaggedEvent)
        };

        private readonly IProjectionRunner<ProductDisplayEntity> _runner;
        private readonly IProjection<ProductDisplayEntity> _projection;
        
        public ProductDisplayProjectionEventSubscriber(
            IProjectionRunner<ProductDisplayEntity> runner, 
            IProjection<ProductDisplayEntity> projection)
        {
            _runner = runner ?? throw new ArgumentNullException(nameof(runner));
            _projection = projection ?? throw new ArgumentNullException(nameof(projection));
        }

        public Task Handle(IEvent @event) => _runner.RunAsync(_projection, @event);

        public bool Handles(Type type) => _supportedTypes.Contains(type);
    }
}