using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Helpers;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class Single : IQuestionType
    {
        private readonly string _verb = "http://adlnet.gov/expapi/verbs/preferred";

        private readonly Dictionary<string, string> _verbDisplays = new Dictionary<string, string>()
        {
            { "en", "preferred" }
        };

        private JArray _choices;

        public Single(JObject questionData)
        {
            if ((questionData != null) && (questionData["answers"] != null) && (questionData["answers"]["choices"] != null)) _choices = (JArray)questionData["answers"]["choices"];
            else _choices = new JArray();
        }

        public bool IsGrouped()
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
            JObject result = new JObject();

            if (questionResponse["answers"] != null)
            {
                foreach (JObject answer in (JArray)questionResponse["answers"])
                {
                    foreach (JObject choice in _choices)
                    {
                        if (((string)choice["id"] != null) && ((string)choice["id"] != (string)answer["choice_id"]))
                        {
                            result["response"] = (string)choice["text"];

                            return result;
                        }
                    }
                }
            }

            result["response"] = null;

            return result;
        }
    }
}
