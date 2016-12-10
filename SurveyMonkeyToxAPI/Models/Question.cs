using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Factories;
using SurveyMonkeyToxAPI.Models.QuestionTypes;
using System;

namespace SurveyMonkeyToxAPI.Models
{
    public class Question
    {
        #region Constructors

        public Question(string surveyId, JObject questionData)
        {
            SurveyId = surveyId;

            if (questionData["id"] != null) Id = (string)questionData["id"];
            else throw new Exception("A quesion id could not be found");

            Heading = GetHeading(questionData);
            if (string.IsNullOrEmpty(Heading)) throw new Exception("A question could not be found for question ID " + Id);

            Position = GetPosition(questionData);

            QuestionType = GetQuestionType(questionData);

            QuestionModule = QuestionTypeFactory.GetQuestionTypeModule(QuestionType, questionData);
            if (QuestionModule == null) throw new Exception("A question module could not be found for " + QuestionType.ToString());
        }

        #endregion

        #region Public Methods

        public JObject GetxAPIStatement(string email, JObject questionResponse)
        {
            // the identifier of the statement
            JObject questionxAPI = new JObject();
            questionxAPI["id"] = System.Guid.NewGuid().ToString();
            questionxAPI["timestamp"] = DateTime.UtcNow.ToString();

            // add the person who took the survey
            questionxAPI["actor"] = new JObject();
            questionxAPI["actor"]["objectType"] = "Agent";
            questionxAPI["actor"]["mbox"] = "mailto:" + email;

            questionxAPI["verb"] = new JObject();
            questionxAPI["id"] = QuestionModule.GetVerb();
            questionxAPI["display"] = QuestionModule.GetReadableVerb();

            questionxAPI["result"] = QuestionModule.GetResultxAPI(questionResponse);

            // add details about the question
            questionxAPI["object"] = new JObject();
            questionxAPI["object"]["id"] = Id;
            questionxAPI["object"]["objectType"] = "Activity";
            questionxAPI["object"]["definition"] = new JObject();
            questionxAPI["object"]["definition"]["name"] = new JObject();
            questionxAPI["object"]["definition"]["name"]["en-US"] = Heading;
            questionxAPI["object"]["definition"]["name"]["type"] = "http://adlnet.gov/expapi/activities/question";

            // add the context of the survey it comes from
            questionxAPI["context"] = new JObject();
            questionxAPI["context"]["contextActivities"] = new JObject();
            questionxAPI["context"]["contextActivities"]["parent"] = new JArray();

            JObject surveyDetail = new JObject();
            surveyDetail["id"] = SurveyId;
            surveyDetail["objectType"] = "Activity";
            surveyDetail["definition"] = new JObject();
            surveyDetail["definition"]["type"] = "https://xapinet.org/activities/survey";

            ((JArray)questionxAPI["context"]["contextActivities"]["parent"]).Add(surveyDetail);

            return questionxAPI;
        }

        #endregion

        #region Private Methods

        private string GetHeading(JObject questionData)
        {
            if (questionData["headings"] != null)
            {
                JArray headings = (JArray)questionData["headings"];

                if ((headings.Count > 0) && (headings.First["heading"] != null)) return (string)headings.First["heading"];
            }

            return string.Empty;
        }

        private int GetPosition(JObject questionData)
        {
            if (questionData["position"] != null)
            {
                // May throw an error
                return (int)questionData["position"];
            }
            else throw new Exception("Unable to find question position");
        }

        private QuestionType GetQuestionType(JObject questionData)
        {
            string family = questionData["family"].ToString();
            string subtype = questionData["subtype"].ToString();

            if (!string.IsNullOrEmpty(family) && !string.IsNullOrEmpty(subtype)) return QuestionTypeFactory.GetQuestionType(family, subtype);
            else return QuestionType.Unknown;
        }

        #endregion

        #region Properties

        public string SurveyId { get; set; }

        public string Id { get; set; }

        public string Heading { get; set; }

        public int Position { get; set; }

        public QuestionType QuestionType { get; set; }

        public IQuestionType QuestionModule { get; set; }

        #endregion
    }
}
