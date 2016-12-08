using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class Demographic : IQuestionType
    {
        private JObject _questionData;

        public Demographic(JObject questionData)
        {
            _questionData = questionData;
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
