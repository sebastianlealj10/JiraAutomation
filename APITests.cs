using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Configuration;

namespace JiraAutomation
{
    [TestFixture]
    public class APITests
    {
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string IssueEndpoint = ConfigurationManager.AppSettings["IssueEndpoint"];
        private readonly string ConfigUsername = ConfigurationManager.AppSettings["Username"];
        private string ConfigPassword = ConfigurationManager.AppSettings["Password"];

        [Test]
        public void ANewEpicIsCreatedUsingTheAPI()
        {
            var restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ConfigUsername, ConfigPassword),
            };
            var request = new RestRequest(IssueEndpoint);
            string body = "{\"fields\": {\"project\":{\"key\": \"DEMO\"},\"summary\": \"My Epic created from the API\",\"description\": \"Creating of an Epic using project keys and issue type names using the REST API\",\"issuetype\": {\"name\": \"Epic\"},\r\n\"customfield_10104\": \"MyEpic\"}}";
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            var response = restClient.Post(request);
            Console.WriteLine(response.Content);
        }
    }
}
