using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class OpenEndedSingle : IQuestionType
    {
        private readonly string _verb = "http://adlnet.gov/expapi/verbs/responded";

        private readonly Dictionary<string, string> _verbDisplays = new Dictionary<string, string>()
        {
            { "en", "responded" }
        };

        public OpenEndedSingle(JObject questionData)
        {
        }

        public JObject GetResultxAPI(Response response)
        {
            throw new NotImplementedException();
        }
    }
}
