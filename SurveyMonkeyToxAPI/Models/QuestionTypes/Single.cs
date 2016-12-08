using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class Single : IQuestionType
    {
        private JObject _questionData;

        public Single(JObject questionData)
        {
            _questionData = questionData;
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
