using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Helpers
{
    public static class SurveyMonkeyHelper
    {
        private static readonly string baseURL = "https://api.surveymonkey.net";

        public static string GetSurvey(string tokenId, string surveyId)
        {
            return RestHelper.PerformGetRequest(baseURL, "v3/surveys/" + surveyId + "/details", GetHeaders(tokenId));
        }

        public static string GetResponses(string tokenId, string surveyId)
        {
            return RestHelper.PerformGetRequest(baseURL, "v3/surveys/" + surveyId + "/responses/bulk", GetHeaders(tokenId));
        }

        private static IDictionary<string, string> GetHeaders(string tokenId)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers["Authorization"] = "bearer " + tokenId;
            headers["Content-Type"] = "application/json";

            return headers;
        }
    }
}
