using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class OpenEndedSingle : IQuestionType
    {
        public OpenEndedSingle(JObject questionData)
        {
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
