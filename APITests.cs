using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using SolutionCore.Builders;
using SolutionCore;

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
        public void AssingANewEpicToAStory()
        {
            var createIssue = new CreateIssueBuilder().
                WithIssueType("Epic").
                WithIssueName("EpicTest").
                Build();
            var issue = new Issue(restClient);
            var objectResponse = issue.CreateIssue(createIssue);
            var statusCodeResponse = issue.UpdateIssue("DEMO-6", objectResponse.key);
            Assert.AreEqual("NoContent", statusCodeResponse);
        }
    }
}
