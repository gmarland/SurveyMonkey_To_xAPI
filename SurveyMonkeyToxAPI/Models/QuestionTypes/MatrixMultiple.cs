using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class MatrixMultiple : IQuestionType
    {
        private JObject _questionData;

        public MatrixMultiple(JObject questionData)
        {
            _questionData = questionData;
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
