﻿using SolutionCore.Builders;
using SolutionCore.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;

namespace SolutionCore
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
