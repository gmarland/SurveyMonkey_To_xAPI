using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class Single : IQuestionType
    {
        private JArray _choices;

        public Single(JObject questionData)
        {
            if ((questionData != null) && (questionData["answers"] != null) && (questionData["answers"]["choices"] != null)) _choices = (JArray)questionData["answers"]["choices"];
            else _choices = new JArray();
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
