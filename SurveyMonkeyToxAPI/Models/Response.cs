using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Helpers;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models
{
    public class Response
    {
        #region Constructors

        public Response(JObject responseData)
        {
            ParseRespondantEmail(responseData);

            Questions = new List<JObject>();

            foreach (JObject page in (JArray)responseData["pages"])
            {
                foreach (JObject question in (JArray)page["questions"])
                {
                    Questions.Add(question);
                }
            }
        }

        #endregion

        #region Public Methods

        public JObject GetQuestion(string questionId)
        {
            foreach (JObject question in Questions)
            {
                if (((string)question["id"] != null) && ((string)question["id"] == questionId))
                {
                    return question;
                }
            }

            return new JObject();
        }

        #endregion

        #region Private Methods

        private void ParseRespondantEmail(JObject responseData)
        {
            if ((responseData["metadata"] != null) && 
                (responseData["metadata"]["contact"] != null) && 
                (responseData["metadata"]["contact"]["email"] != null) && 
                (responseData["metadata"]["contact"]["email"]["value"] != null))
            {
                string email = (string)responseData["metadata"]["contact"]["email"]["value"];

                if (TextHelper.IsValidEmail(email))
                {
                    Email = email;
                    return;
                }
            }

            foreach (JObject page in (JArray)responseData["pages"])
            {
                JArray questions = (JArray)page["questions"];

                for (var i=(questions.Count-1); i>=0; i--)
                {
                    JObject question = (JObject)questions[i];

                    foreach (JObject answer in (JArray)question["answers"])
                    {
                        if ((answer["text"] != null) && (TextHelper.IsValidEmail((string)answer["text"])))
                        {
                            Email = (string)answer["text"];
                            EmailQuestionId = (string)question["id"];

                            questions.RemoveAt(i);

                            return;
                        }
                    }
                }
            }

            Email = string.Empty;
            EmailQuestionId = string.Empty;
        }

        #endregion

        #region Properties

        public string Email { get; set; }

        public string EmailQuestionId { get; set; }

        public IList<JObject> Questions { get; set; }

        #endregion
    }
}
