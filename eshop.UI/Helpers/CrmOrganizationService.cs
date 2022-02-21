using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.ServiceModel.Description;

namespace eshop.UI.Helpers
{
    public static class CrmOrganizationService
    {
        public const string CrmOrganizationServicePath = "XRMServices/2011/Organization.svc";

        public static IOrganizationService GetCrmOrganizationServiceProxy(string crmConnectionString)
        {
            return CreateCrmOrganizationServiceProxy(crmConnectionString);
        }

        public static IOrganizationService GetImpersonatedCrmOrganizationServiceProxy(string crmConnectionString, Guid userId)
        {
            return CreateCrmOrganizationServiceProxy(crmConnectionString, userId);
        }

        private static IOrganizationService CreateCrmOrganizationServiceProxy(string crmConnectionString, Guid? callerId = null)
        {
            var connection = ConnectionStringToDictionary(crmConnectionString);
            var username = connection.GetValueByKey<string>("username");
            var password = connection.GetValueByKey<string>("password");
            var url = connection.GetValueByKey<string>("url");

            var credentials = new ClientCredentials
            {
                UserName =
                {
                    UserName = username,
                    Password = password
                }
            };

            var serviceUri = NormalizeOrganizationServiceUrl(url);
            var proxy = new OrganizationServiceProxy(new Uri(serviceUri), null, credentials, null);
            proxy.Timeout = new TimeSpan(0, 15, 0);
            if (callerId != null) proxy.CallerId = callerId.Value;

            proxy.EnableProxyTypes();
            return proxy;
        }

        private static Dictionary<string, object> ConnectionStringToDictionary(string crmConnectionString)
        {
            var builder = new DbConnectionStringBuilder { ConnectionString = crmConnectionString };
            return builder.Cast<KeyValuePair<string, object>>().ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private static string NormalizeOrganizationServiceUrl(string url)
        {
            if (!url.EndsWith(CrmOrganizationServicePath))
            {
                if (!url.EndsWith("/"))
                {
                    url += "/";
                }
                url += CrmOrganizationServicePath;
            }
            return url;
        }
    }
}