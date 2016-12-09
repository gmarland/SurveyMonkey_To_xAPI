using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class OpenEndedMulti : IQuestionType
    {
        private JArray _rows;

        public OpenEndedMulti(JObject questionData)
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
