using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using SurveyMonkeyToxAPI.Helpers;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class MatrixRanking : IQuestionType
    {
        private readonly string _verb = "http://adlnet.gov/expapi/verbs/preferred";

        private readonly Dictionary<string, string> _verbDisplays = new Dictionary<string, string>()
        {
            { "en", "preferred" }
        };

        private JArray _rows;
        private JArray _choices;

        public MatrixRanking(JObject questionData)
        {
            if (questionData != null)
            {
                if ((questionData["answers"] != null) && (questionData["answers"]["rows"] != null)) _rows = (JArray)questionData["answers"]["rows"];
                else _rows = new JArray();

                if ((questionData["answers"] != null) && (questionData["answers"]["choices"] != null)) _choices = (JArray)questionData["answers"]["choices"];
                else _choices = new JArray();
            }
        }

        public bool IsMatrix()
        {
            return true;
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
