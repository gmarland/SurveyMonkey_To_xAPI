using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Helpers;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class MatrixRating : IQuestionType
    {
        private readonly string _verb = "http://adlnet.gov/expapi/verbs/rated";

        private readonly Dictionary<string, string> _verbDisplays = new Dictionary<string, string>()
        {
            { "en", "rated" }
        };

        private JArray _rows;
        private JArray _choices;

        public MatrixRating(JObject questionData)
        {
            if (questionData != null)
            {
                if ((questionData["answers"] != null) && (questionData["answers"]["rows"] != null)) _rows = (JArray)questionData["answers"]["rows"];
                else _rows = new JArray();

                if ((questionData["answers"] != null) && (questionData["answers"]["choices"] != null)) _choices = (JArray)questionData["answers"]["choices"];
                else _choices = new JArray();
            }
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
