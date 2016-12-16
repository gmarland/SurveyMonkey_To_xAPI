using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Helpers;
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
                foreach (JObject answer in (JArray)questionResponse["answers"])
                {
                    if (answer["text"] != null)
                    {
                        JObject result = new JObject();
                        result["response"] = (string)answer["text"];

                        return result;
                    }
                }
            }

            return new JObject();
        }
    }
}
