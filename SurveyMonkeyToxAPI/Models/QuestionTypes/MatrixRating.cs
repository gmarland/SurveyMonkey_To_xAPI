using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class MatrixRating : IQuestionType
    {
        private JObject _questionData;

        public MatrixRating(JObject questionData)
        {
            _questionData = questionData;
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
