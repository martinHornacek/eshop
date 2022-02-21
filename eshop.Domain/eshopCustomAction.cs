using eshop.Domain.Commands;
using eshop.Domain.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Text.Json;

namespace eshop.Domain.CustomAction
{
    public class eshopCustomAction : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (context.InputParameters.Contains("payload") && context.InputParameters["payload"] is string)
            {
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.InitiatingUserId);

                string payload = (string)context.InputParameters["payload"];
                var command = JsonSerializer.Deserialize<RenameQuote>(payload); // explicitly expecting RenameQuote command
                var model = new Quote(); // create (domain) model for Quote
                model.RenameQuote(command.NewName);

            }
        }
    }
}
