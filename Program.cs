using System;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace Dataverse0AuthConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            string crmUrl = "https://yourorg.crm6.dynamics.com";    //e.g. https://org554545.crm6.dynamics.com
            string clientId = "yourAzureAppClientID";               // e.g. 661y8Q~f6568O5dwweweevo~E8989COX5c3LcSz
            string secretKey = "yourAzureClientSecretKey";          // e.g. d5dfdfdfee661y8Q~f6568O5vo~E8989COX5c3LcSz
            CrmServiceClient dvc = new CrmServiceClient(new Uri(crmUrl), clientId, secretKey, false, "");
            if (dvc != null && dvc.IsReady)
            {
                var resp1 = (WhoAmIResponse)dvc.Execute(new WhoAmIRequest()); //Executing the WhoAmi Request
                Guid orgId = (Guid)resp1["OrganizationId"];                   //Extracing the Organization ID
                Guid userId = (Guid)resp1["UserId"];                          // Extracting the user ID
                Console.WriteLine("Your OrganizationId is {0}", orgId);
                Console.WriteLine("Your UserId is {0}", userId);
                Console.ReadLine();                                           // Keeping the console open
            }
        }
    }
}