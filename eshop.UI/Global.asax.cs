using eshop.Domain.Commands;
using eshop.Domain.Events;
using eshop.Domain.Models;
using eshop.Infrastructure;
using eshop.Infrastructure.Handlers;
using eshop.Infrastructure.Models;
using eshop.UI.Helpers;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eshop.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bus = new FakeBus();

            var storage = new EventStore(bus);
            var repository = new Repository<Quote>(storage);

            var commands = new QuoteCommandHandlers(repository);
            bus.RegisterHandler<AddQuoteProductsToQuote>(commands.Handle);
            bus.RegisterHandler<CreateQuote>(commands.Handle);
            bus.RegisterHandler<ActivateQuote>(commands.Handle);
            bus.RegisterHandler<RemoveQuoteProductsFromQuote>(commands.Handle);
            //bus.RegisterHandler<RenameQuote>(commands.Handle);

            var crmConnectionString = ConfigurationManager.AppSettings["CrmConnectionString"];
            var crmOrganizationService = CrmOrganizationService.GetCrmOrganizationServiceProxy(crmConnectionString);
            var crmPublisher = new QuoteCommandCrmPublisher(crmOrganizationService);
            bus.RegisterHandler<RenameQuote>(crmPublisher.Publish);

            var quoteProducts = new QuoteProductsView();
            bus.RegisterHandler<QuoteCreated>(quoteProducts.Handle);
            bus.RegisterHandler<QuoteActivated>(quoteProducts.Handle);
            bus.RegisterHandler<QuoteRenamed>(quoteProducts.Handle);
            bus.RegisterHandler<QuoteProductsAddedToQuote>(quoteProducts.Handle);
            bus.RegisterHandler<QuoteProductsRemovedFromQuote>(quoteProducts.Handle);

            var quote = new QuoteView();
            bus.RegisterHandler<QuoteCreated>(quote.Handle);
            bus.RegisterHandler<QuoteRenamed>(quote.Handle);
            bus.RegisterHandler<QuoteActivated>(quote.Handle);

            ServiceLocator.Bus = bus;
        }
    }
}
