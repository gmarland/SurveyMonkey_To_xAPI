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
                            foreach (JObject choice in _choices)
                            {
                                if ((string)choice["id"] == (string)answer["choice_id"])
                                {
                                    if ((choice["text"] != null) && (!string.IsNullOrEmpty((string)choice["text"]))) question["response"] = (string)choice["text"];
                                    else question["response"] = (string)choice["weight"];
                                    break;
                                }
                            }
                        }

                        ((JArray)groupingJSON["questions"]).Add(question);
                    }
                }
            }

            return groupingJSON;
        }
    }
}
