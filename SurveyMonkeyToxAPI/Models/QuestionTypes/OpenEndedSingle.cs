using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class OpenEndedSingle : IQuestionType
    {
        private JObject _questionData;

        public OpenEndedSingle(JObject questionData)
        {
            _questionData = questionData;
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
