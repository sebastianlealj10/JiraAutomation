﻿using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace JiraAutomation
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var restClient = new RestClient("http://localhost:8080")
            {
                Authenticator = new HttpBasicAuthenticator("sebas.adm1n10", "sebas12"),
            };
            var request = new RestRequest("/rest/api/latest/issue/");
            string body = "{\"fields\": {\"project\":{\"key\": \"DEMO\"},\"summary\": \"My Epic created from the API\",\"description\": \"Creating of an Epic using project keys and issue type names using the REST API\",\"issuetype\": {\"name\": \"Epic\"},\r\n\"customfield_10103\": \"MyEpic\"}}";
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            var response = restClient.Post(request);
            Console.WriteLine(response);
        }
    }
}
