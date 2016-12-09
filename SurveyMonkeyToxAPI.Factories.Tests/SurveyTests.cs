using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyMonkeyToxAPI.Models;
using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI.Factories.Tests
{
    [TestClass]
    public class SurveyTests
    {
        private string _surveyJSON = "{ \"title\": \"My Survey\", \"nickname\": \"\", \"category\": \"\", \"language\": \"en\", \"question_count\": 0, \"page_count\": 0, \"date_created\": \"2015-10-06T12:56:55+00:00\", \"date_modified\": \"2015-10-06T12:56:55+00:00\", \"id\": \"1234\", \"href\": \"http://api.surveymonkey.com/v3/surveys/1234\", \"buttons_text\": { \"done_button\": \"Done\", \"prev_button\": \"Prev\", \"exit_button\": \"Exit\", \"next_button\": \"Next\" }, \"custom_variables\": { \"name\": \"label\" }, \"preview\": \"https://www.surveymonkey.com/r/Preview/\", \"edit_url\": \"https://www.surveymonkey.com/create/\", \"collect_url\": \"https://www.surveymonkey.com/collect/list\", \"analyze_url\": \"https://www.surveymonkey.com/analyze/\", \"summary_url\": \"https://www.surveymonkey.com/summary/\", \"response_count\": 12 }";

        [TestMethod]
        public void GetSurveyStringPassing()
        {
            Survey survey = new Survey(_surveyJSON);

            TestValidSurvey(survey);
        }

        [TestMethod]
        public void GetSurveyJSONPassing()
        {
            JObject surveyJObject = JObject.Parse(_surveyJSON);

            Survey survey = new Survey(surveyJObject);

            TestValidSurvey(survey);
        }
        
        private void TestValidSurvey(Survey survey)
        {
            Assert.AreEqual("1234", survey.Id);
            Assert.AreEqual("My Survey", survey.Title);
            Assert.AreEqual("en", survey.Language);
            Assert.AreEqual(DateTime.Parse("2015-10-06T12:56:55+00:00"), survey.Created);
            Assert.AreEqual(DateTime.Parse("2015-10-06T12:56:55+00:00"), survey.Modified);
        }
    }
}
