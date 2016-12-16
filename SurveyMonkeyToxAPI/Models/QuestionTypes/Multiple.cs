using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Helpers;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class Multiple : IQuestionType
    {
        private readonly string _verb = "http://adlnet.gov/expapi/verbs/preferred";

        private readonly Dictionary<string, string> _verbDisplays = new Dictionary<string, string>()
        {
            { "en", "preferred" }
        };

        private JArray _choices;

        public Multiple(JObject questionData)
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
            if (questionResponse["answers"] != null)
            {
                JObject result = new JObject();
                result["extensions"] = new JObject();

                foreach (JObject answer in (JArray)questionResponse["answers"])
                {
                    foreach (JObject choice in _choices)
                    {
                        if (((string)choice["id"] != null) && ((string)choice["id"] != (string)answer["choice_id"]))
                        {
                            result["extensions"][(string)answer["choice_id"]] = (string)choice["text"];
                        }
                    }
                }

                return result;
            }

            return new JObject();
        }
    }
}
