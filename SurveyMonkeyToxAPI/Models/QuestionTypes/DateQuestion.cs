using System;
using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class DateQuestion : IQuestionType
    {
        private JArray _rows;

        public DateQuestion(JObject questionData)
        {
            if ((questionData["answers"] != null) && (questionData["answers"]["rows"] != null)) _rows = (JArray)questionData["answers"]["rows"];
            else _rows = new JArray();
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
