using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Helpers;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class OpenEndedNumerical : IQuestionType
    {
        private readonly string _verb = "http://adlnet.gov/expapi/verbs/responded";

        private readonly Dictionary<string, string> _verbDisplays = new Dictionary<string, string>()
        {
            { "en", "responded" }
        };

        private JArray _rows;

        public OpenEndedNumerical(JObject questionData)
        {
            if ((questionData != null) && (questionData["answers"] != null) && (questionData["answers"]["rows"] != null)) _rows = (JArray)questionData["answers"]["rows"];
            else _rows = new JArray();
        }

        public bool IsGrouped()
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
            JObject groupingJSON = new JObject();
            groupingJSON["groupingId"] = (string)questionResponse["id"];

            groupingJSON["questions"] = new JArray();

            foreach (JObject row in _rows)
            {
                if (questionResponse["answers"] != null)
                {
                    foreach (JObject answer in questionResponse["answers"])
                    {
                        JObject question = new JObject();

                        question["id"] = (string)row["id"];

                        if (row["text"] != null) question["text"] = row["text"];
                        else question["text"] = string.Empty;

                        if ((string)row["id"] == (string)answer["row_id"])
                        {
                            if (answer["text"] != null) question["response"] = (string)answer["text"];
                        }

                        ((JArray)groupingJSON["questions"]).Add(question);
                    }
                }
            }

            return groupingJSON;
        }
    }
}
