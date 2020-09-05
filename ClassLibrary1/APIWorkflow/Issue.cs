﻿using ClassLibrary1.Models;
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

        public string CreateIssue (IssueCreation issueCreation)
        {
            var request = new RestRequest(IssueEndpoint);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(issueCreation);
            return restClient.Post(request).Content;
        }

    }
}
