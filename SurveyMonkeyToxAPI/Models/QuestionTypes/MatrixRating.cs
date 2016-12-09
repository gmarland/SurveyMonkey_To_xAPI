using Newtonsoft.Json.Linq;
using System;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public class MatrixRating : IQuestionType
    {
        private JArray _rows;
        private JArray _choices;

        public MatrixRating(JObject questionData)
        {
            if (questionData != null)
            {
                if ((questionData["answers"] != null) && (questionData["answers"]["rows"] != null)) _rows = (JArray)questionData["answers"]["rows"];
                else _rows = new JArray();

                if ((questionData["answers"] != null) && (questionData["answers"]["choices"] != null)) _choices = (JArray)questionData["answers"]["choices"];
                else _choices = new JArray();
            }
        }

        public JObject GetxAPIStatement()
        {
            throw new NotImplementedException();
        }
    }
}
