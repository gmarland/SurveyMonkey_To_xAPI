using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class OpenEndedNumerical : IQuestionType
    {
        private JArray _rows;

        public OpenEndedNumerical(JObject questionData)
        {
            if ((questionData != null) && (questionData["answers"] != null) && (questionData["answers"]["rows"] != null)) _rows = (JArray)questionData["answers"]["rows"];
            else _rows = new JArray();
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
