using ClassLibrary1.Builders;
using ClassLibrary1.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Issue
    {
        private readonly string IssueEndpoint = ConfigurationManager.AppSettings["IssueEndpoint"];
        RestClient restClient;
        public Issue(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public CreateIssueResponse CreateIssue (IssueCreation issueCreation)
        {
            var request = new RestRequest(IssueEndpoint);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(issueCreation);
            var content = restClient.Post(request).Content;
            return JsonConvert.DeserializeObject<CreateIssueResponse>(content);
        }

        public string UpdateIssue(string issueToUpdate, string epic)
        {
            var request = new RestRequest(IssueEndpoint + issueToUpdate);
            var updateBody = new UpdateIssueBuilder()
                .WithIssueToUpdate(epic)
                .Build();
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(updateBody);
            var response = restClient.Put(request);
            return response.StatusCode.ToString();
        }

    }
}
