using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models
{
    public class Survey
    {
        public Survey(string surveyJSON)
        {
            JObject surveyJObject = JObject.Parse(surveyJSON);

            PopulateSurvey(surveyJObject);
        }

        public Survey(JObject surveyJObject)
        {
            PopulateSurvey(surveyJObject);
        }

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

            Pages = new List<Page>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Language { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public IList<Page> Pages { get; set; }
    }
}
