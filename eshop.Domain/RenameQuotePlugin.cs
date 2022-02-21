using eshop.Domain.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.ServiceModel;

namespace eshop.Dynamics.Plugin
{
    public class RenameQuotePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity preImage = context.PreEntityImages["PreImage"];
                Entity entity = (Entity)context.InputParameters["Target"];

                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.InitiatingUserId);

                try
                {
                    var oldName = preImage.GetAttributeValue<string>("name");
                    var newName = entity.GetAttributeValue<string>("name");
                    if (oldName != newName)
                    {
                        var model = new Quote(); // create (domain) model for Quote
                        model.RenameQuote(newName);
                    }
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in RenameQuotePlugin.", ex);
                }

                catch (Exception ex)
                {
                    tracingService.Trace("RenameQuotePlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
