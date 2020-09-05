using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using ClassLibrary1;
using System;

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
        public void setUp()
        {
            restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ConfigUsername, ConfigPassword),
            };
        }

        [Test]
        public void ANewEpicIsCreatedUsingTheAPI()
        {
            var issue = new Issue(restClient);
            Console.WriteLine(issue.CreateIssue("Epic"));
        }
    }
}
