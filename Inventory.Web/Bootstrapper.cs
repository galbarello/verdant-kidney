using Inventory.Handlers;
using Inventory.Logic;
using Inventory.Logic.Abstractions;
using Inventory.Messaging;
using Inventory.Repositories;
using Inventory.Services;
using Inventory.Services.Abstractions;
using Inventory.Web.Services;
using Nancy;

namespace Inventory.Web
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            Wiring.Wire();
            base.ApplicationStartup(container, pipelines);
            
            container.Register<IProductRepository, ProductRepository>().AsSingleton();
            container.Register<IProductService, ProductService>().AsSingleton();
            container.Register<IProductLogic, ProductLogic>().AsSingleton();
        }
    }

    public static class Wiring
    {
        public static void Wire()
        {
            var bus = new MiniVan();

            var storage = new RestStore();
            var rep = new Repository<InventoryItem>(storage);
            var commands = new InventoryCommandHandlers(rep);
            bus.RegisterHandler<CheckInItemsToInventory>(commands.Handle);
            bus.RegisterHandler<CreateInventoryItem>(commands.Handle);
            bus.RegisterHandler<DeactivateInventoryItem>(commands.Handle);
            bus.RegisterHandler<RemoveItemsFromInventory>(commands.Handle);
            bus.RegisterHandler<RenameInventoryItem>(commands.Handle);
            ServiceLocator.Bus = bus;
        }
    }

}