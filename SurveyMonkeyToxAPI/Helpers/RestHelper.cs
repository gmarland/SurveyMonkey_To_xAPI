using RestSharp;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Helpers
{
    public static class RestHelper
    {
        public static string PerformGetRequest(string baseURL, string resource, IDictionary<string, string> headers)
        {
            RestClient client = new RestClient(baseURL);

            RestRequest request = new RestRequest(resource, Method.GET);

            foreach (string key in headers.Keys) request.AddHeader(key, headers[key]);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return response.Content;
            else throw new Exception("Error requesting '" + resource + "': " + response.StatusCode.ToString());
        }
    }
}
