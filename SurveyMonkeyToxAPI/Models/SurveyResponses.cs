using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SurveyMonkeyToxAPI.Models
{
    public class SurveyResponses
    {
        #region Constructors

        public SurveyResponses(string surveyResponseJSON)
        {
            Responses = new List<Response>();

            JObject surveyResponseJObject = JObject.Parse(surveyResponseJSON);

            PopulateSurveyResponses(surveyResponseJObject);
        }

        public SurveyResponses(JObject surveyResponseJObject)
        {
            Responses = new List<Response>();

            PopulateSurveyResponses(surveyResponseJObject);
        }

        #endregion

        #region Public Methods

        public IList<Response> GetAllValidResponses()
        {
            return Responses.Where(r => !string.IsNullOrEmpty(r.Email)).ToList();
        }

        public IList<string> GetEmailQuestionIds()
        {
            return Responses.Where(r => !string.IsNullOrEmpty(r.EmailQuestionId)).Select(r => r.EmailQuestionId).Distinct().ToList();
        }

        #endregion

        #region Private Methods

        private void PopulateSurveyResponses(JObject surveyResponseJObject)
        {
            if (surveyResponseJObject["data"] != null)
            {
                JArray surveyData = (JArray)surveyResponseJObject["data"];

                foreach (JObject response in surveyData)
                {
                    Responses.Add(new Response(response));
                }
            }
        }

        #endregion

        #region Properties

        public IList<Response> Responses { get; set; }

        #endregion
    }
}
