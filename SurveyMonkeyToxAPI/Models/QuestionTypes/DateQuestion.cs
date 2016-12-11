using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using SurveyMonkeyToxAPI.Helpers;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class DateQuestion : IQuestionType
    {
        private readonly string _verb = "http://adlnet.gov/expapi/verbs/responded";

        private readonly Dictionary<string, string> _verbDisplays = new Dictionary<string, string>()
        {
            { "en", "responded" }
        };

        private JArray _rows;

        public DateQuestion(JObject questionData)
        {
            if ((questionData != null) && (questionData["answers"] != null) && (questionData["answers"]["rows"] != null)) _rows = (JArray)questionData["answers"]["rows"];
            else _rows = new JArray();
        }

        public bool IsMatrix()
        {
            return false;
        }

        public string GetVerb()
        {
            return _verb;
        }

        public JObject GetReadableVerb()
        {
            return JSONHelper.DictionaryToJSON(_verbDisplays);
        }

        public JObject GetResultxAPI(JObject questionResponse)
        {
            throw new NotImplementedException();
        }
    }
}
