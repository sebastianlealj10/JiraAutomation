using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using ClassLibrary1;
using System;
using ClassLibrary1.Builders;

namespace JiraAutomation
{
    [TestFixture]
    public class APITests
    {
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string ConfigUsername = ConfigurationManager.AppSettings["Username"];
        private readonly string ConfigPassword = ConfigurationManager.AppSettings["Password"];

        RestClient restClient;

        [SetUp]
        public void SetUp()
        {
            restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ConfigUsername, ConfigPassword),
            };
        }

        [Test]
        public void ANewEpicIsCreatedUsingTheAPI()
        {
            var createIssue = new CreateIssueBuilder().Build();
            var issue = new Issue(restClient);
            Console.WriteLine(issue.CreateIssue(createIssue));
        }
    }
}
