using eshop.Domain.Commands;
using Microsoft.Xrm.Sdk;
using System.Text.Json;

namespace eshop.Infrastructure.Handlers
{
    public class QuoteCommandCrmPublisher
    {
        private readonly IOrganizationService _crmOrganizationService;

        public QuoteCommandCrmPublisher(IOrganizationService crmOrganizationService)
        {
            _crmOrganizationService = crmOrganizationService;
        }

        public void Publish(RenameQuote message)
        {
            var payload = JsonSerializer.Serialize(message, options: new JsonSerializerOptions { IncludeFields = true });

            _crmOrganizationService.Execute(new OrganizationRequest
            {
                RequestName = "new_eshop",
                Parameters =
                {
                    ["payload"] = payload
                }
            });
        }
    }
}
