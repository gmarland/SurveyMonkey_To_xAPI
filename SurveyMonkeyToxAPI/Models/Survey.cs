using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyMonkeyToxAPI.Models
{
    public class Survey
    {
        #region Constructors

        public Survey(string surveyJSON)
        {
            JObject surveyJObject = JObject.Parse(surveyJSON);

            PopulateSurvey(surveyJObject);
        }

        public Survey(JObject surveyJObject)
        {
            PopulateSurvey(surveyJObject);
        }

        #endregion

        #region Public Methods

        public IList<Question> GetValidQuestions(IList<string> emailQuestionIds)
        {
            List<Question> questions = new List<Question>();

            foreach (Page page in Pages)
            {
                questions.AddRange(page.Questions.Where(q => !emailQuestionIds.Contains(q.Id)));
            }

            return questions;
        }

        #endregion

        #region Public Methods
        
        public JObject GetxAPIStatement(Response response)
        {
            JObject surveyxAPI = new JObject();

            surveyxAPI["timestamp"] = DateTime.UtcNow.ToString();

            // add the person who took the survey
            surveyxAPI["actor"] = new JObject();
            surveyxAPI["actor"]["objectType"] = "Agent";
            surveyxAPI["actor"]["mbox"] = "mailto:" + response.Email;

            // add the person who took the survey
            surveyxAPI["verb"] = new JObject();
            surveyxAPI["verb"]["id"] = "http://adlnet.gov/expapi/verbs/completed";
            surveyxAPI["verb"]["display"] = new JObject();
            surveyxAPI["verb"]["display"]["en-US"] = "completed";

            // add the details of the survey
            surveyxAPI["object"] = new JObject();
            surveyxAPI["object"]["id"] = Id;
            surveyxAPI["object"]["objectType"] = "Activity";
            surveyxAPI["object"]["definition"] = new JObject();
            surveyxAPI["object"]["definition"]["type"] = "https://xapinet.org/activities/survey";

            surveyxAPI["result"] = new JObject();
            surveyxAPI["result"]["completion"] = true;

            return surveyxAPI;
        }

        #endregion

        #region Private Methods

        private void PopulateSurvey(JObject surveyJObject)
        {
            if (surveyJObject["id"] != null) Id = (string)surveyJObject["id"];
            else throw new Exception("A survey id could not be found");

            if (surveyJObject["title"] != null) Title = (string)surveyJObject["title"];
            else throw new Exception("A survey title could not be found");

            if (surveyJObject["language"] != null) Language = (string)surveyJObject["language"];
            else throw new Exception("A survey language could not be found");

            if (surveyJObject["date_created"] != null) Created = (DateTime)surveyJObject["date_created"];
            else throw new Exception("A survey date_created could not be found");

            if (surveyJObject["date_modified"] != null) Modified = (DateTime)surveyJObject["date_modified"];
            else throw new Exception("A survey date_modified could not be found");

            if (surveyJObject["pages"] != null) Pages = ParsePages((JArray)surveyJObject["pages"]);
            else Pages = new List<Page>();
        }

        private List<Page> ParsePages(JArray pages)
        {
            List<Page> builtPages = new List<Page>();

            foreach (JObject page in pages)
            {
                builtPages.Add(new Page(Id, page));
            }

            return builtPages;
        }

        #endregion

        #region Properties

        public string Id { get; set; }

        public string Title { get; set; }

        public string Language { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public IList<Page> Pages { get; set; }

        #endregion
    }
}
