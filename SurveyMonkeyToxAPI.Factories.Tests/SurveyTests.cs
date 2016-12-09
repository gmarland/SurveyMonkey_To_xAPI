using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyMonkeyToxAPI.Models;
using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI.Factories.Tests
{
    [TestClass]
    public class SurveyTests
    {
        private string _surveyJSON = "{ \"response_count\": 1, \"page_count\": 2, \"buttons_text\": { \"done_button\": \"Done\", \"prev_button\": \"Prev\", \"exit_button\": \"Exit this survey\", \"next_button\": \"Next\" }, \"custom_variables\": {}, \"nickname\": \"\", \"id\": \"29046621\", \"question_count\": 9, \"category\": \"industry_specific\", \"preview\": \"http://www.surveymonkey.com/r/Preview/?sm=jY7kfxZZ9WO_2BlVJIy8NqOzOqGi5vKBBmYy7K2QB3jFI_3D\", \"is_owner\": true, \"language\": \"en\", \"date_modified\": \"2016-12-09T02:23:00\", \"title\": \"Test Survey\", \"analyze_url\": \"http://www.surveymonkey.com/analyze/H5kuGlfExUEWdjnqay7jS_2FG_2FXK4n0pa_2FUS7uwvGGgOU_3D\", \"pages\": [ { \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920\", \"description\": \"\", \"questions\": [ { \"sorting\": null, \"family\": \"single_choice\", \"subtype\": \"vertical\", \"required\": null, \"answers\": { \"choices\": [ { \"visible\": true, \"text\": \"Answer 1\", \"position\": 1, \"id\": \"10808578431\" }, { \"visible\": true, \"text\": \"Answer 2\", \"position\": 2, \"id\": \"10808578432\" }, { \"visible\": true, \"text\": \"Answer 3\", \"position\": 3, \"id\": \"10808578433\" }, { \"visible\": true, \"text\": \"Answer 4\", \"position\": 4, \"id\": \"10808578434\" } ] }, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686238\", \"headings\": [ { \"heading\": \"This is a multiple choice\" } ], \"position\": 1, \"validation\": null, \"id\": \"1047686238\", \"forced_ranking\": false }, { \"display_options\": { \"middle_label\": \"\", \"show_display_number\": true, \"display_subtype\": \"star\", \"right_label\": \"\", \"display_type\": \"emoji\", \"custom_options\": { \"color\": \"#f5a623\", \"option_set\": [] }, \"left_label\": \"\" }, \"sorting\": null, \"family\": \"matrix\", \"subtype\": \"rating\", \"required\": null, \"answers\": { \"rows\": [ { \"visible\": true, \"text\": \"\", \"position\": 1, \"id\": \"10808578479\" } ], \"choices\": [ { \"description\": \"\", \"weight\": 1, \"id\": \"10808578480\", \"visible\": true, \"is_na\": false, \"text\": \"\", \"position\": 1 }, { \"description\": \"\", \"weight\": 2, \"id\": \"10808578481\", \"visible\": true, \"is_na\": false, \"text\": \"\", \"position\": 2 }, { \"description\": \"\", \"weight\": 3, \"id\": \"10808578482\", \"visible\": true, \"is_na\": false, \"text\": \"\", \"position\": 3 }, { \"description\": \"\", \"weight\": 4, \"id\": \"10808578483\", \"visible\": true, \"is_na\": false, \"text\": \"\", \"position\": 4 }, { \"description\": \"\", \"weight\": 5, \"id\": \"10808578484\", \"visible\": true, \"is_na\": false, \"text\": \"\", \"position\": 5 } ] }, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686242\", \"headings\": [ { \"heading\": \"This is a star rating\" } ], \"position\": 2, \"validation\": null, \"id\": \"1047686242\", \"forced_ranking\": false }, { \"sorting\": null, \"family\": \"matrix\", \"subtype\": \"rating\", \"required\": null, \"answers\": { \"rows\": [ { \"visible\": true, \"text\": \"Row 1\", \"position\": 1, \"id\": \"10808579317\" }, { \"visible\": true, \"text\": \"Row 2\", \"position\": 2, \"id\": \"10808579318\" }, { \"visible\": true, \"text\": \"Row 3\", \"position\": 3, \"id\": \"10808579319\" } ], \"choices\": [ { \"description\": \"\", \"weight\": 1, \"id\": \"10808579320\", \"visible\": true, \"is_na\": false, \"text\": \"Column 1\", \"position\": 1 }, { \"description\": \"\", \"weight\": 2, \"id\": \"10808579321\", \"visible\": true, \"is_na\": false, \"text\": \"Column 2\", \"position\": 2 }, { \"description\": \"\", \"weight\": 3, \"id\": \"10808579322\", \"visible\": true, \"is_na\": false, \"text\": \"Column 3\", \"position\": 3 }, { \"description\": \"\", \"weight\": 4, \"id\": \"10808579323\", \"visible\": true, \"is_na\": false, \"text\": \"Column 4\", \"position\": 4 } ] }, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686363\", \"headings\": [ { \"heading\": \"This is a matrix scale\" } ], \"position\": 3, \"validation\": null, \"id\": \"1047686363\", \"forced_ranking\": false }, { \"sorting\": null, \"family\": \"matrix\", \"subtype\": \"ranking\", \"required\": null, \"answers\": { \"rows\": [ { \"visible\": true, \"text\": \"Row 1\", \"position\": 1, \"id\": \"10808580133\" }, { \"visible\": true, \"text\": \"Row 2\", \"position\": 2, \"id\": \"10808580134\" }, { \"visible\": true, \"text\": \"Row 3\", \"position\": 3, \"id\": \"10808580135\" } ], \"choices\": [ { \"description\": \"\", \"weight\": 1, \"id\": \"10808580136\", \"visible\": true, \"is_na\": false, \"text\": \"1\", \"position\": 1 }, { \"description\": \"\", \"weight\": 2, \"id\": \"10808580137\", \"visible\": true, \"is_na\": false, \"text\": \"2\", \"position\": 2 }, { \"description\": \"\", \"weight\": 3, \"id\": \"10808580138\", \"visible\": true, \"is_na\": false, \"text\": \"3\", \"position\": 3 } ] }, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686456\", \"headings\": [ { \"heading\": \"This is a ranking\" } ], \"position\": 4, \"validation\": null, \"id\": \"1047686456\", \"forced_ranking\": false }, { \"display_options\": { \"middle_label\": \"\", \"show_display_number\": true, \"display_subtype\": \"\", \"right_label\": \"100\", \"display_type\": \"slider\", \"custom_options\": { \"starting_position\": 0, \"option_set\": [], \"step_size\": 1 }, \"left_label\": \"0\" }, \"sorting\": null, \"family\": \"open_ended\", \"subtype\": \"single\", \"required\": null, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686579\", \"headings\": [ { \"heading\": \"This is a slider\" } ], \"position\": 5, \"validation\": { \"sum_text\": \"\", \"min\": \"0\", \"text\": \"Please enter a whole number between {0} and {1}.\", \"sum\": null, \"max\": \"100\", \"type\": \"integer\" }, \"id\": \"1047686579\", \"forced_ranking\": false }, { \"sorting\": null, \"family\": \"open_ended\", \"subtype\": \"single\", \"required\": null, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686621\", \"headings\": [ { \"heading\": \"This is a single textbox\" } ], \"position\": 6, \"validation\": null, \"id\": \"1047686621\", \"forced_ranking\": false }, { \"sorting\": null, \"family\": \"open_ended\", \"subtype\": \"multi\", \"required\": null, \"answers\": { \"rows\": [ { \"visible\": true, \"text\": \"Label 1\", \"position\": 1, \"id\": \"10808582238\" }, { \"visible\": true, \"text\": \"Label 2\", \"position\": 2, \"id\": \"10808582239\" }, { \"visible\": true, \"text\": \"Label 3\", \"position\": 3, \"id\": \"10808582240\" } ] }, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686677\", \"headings\": [ { \"heading\": \"This is a multiple textbox\" } ], \"position\": 7, \"validation\": null, \"id\": \"1047686677\", \"forced_ranking\": false }, { \"sorting\": null, \"family\": \"open_ended\", \"subtype\": \"essay\", \"required\": null, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/124139920/questions/1047686717\", \"headings\": [ { \"heading\": \"This is a comment box\" } ], \"position\": 8, \"validation\": null, \"id\": \"1047686717\", \"forced_ranking\": false } ], \"title\": \"Page 1\", \"position\": 1, \"id\": \"124139920\", \"question_count\": 8 }, { \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/99241017\", \"description\": \"Test Description\", \"questions\": [ { \"sorting\": null, \"family\": \"datetime\", \"subtype\": \"both\", \"required\": null, \"answers\": { \"rows\": [ { \"visible\": true, \"text\": \"Date / Time\", \"position\": 1, \"id\": \"10808583415\" } ] }, \"visible\": true, \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621/pages/99241017/questions/1047686867\", \"headings\": [ { \"heading\": \"This is a date time\" } ], \"position\": 1, \"validation\": { \"sum_text\": \"\", \"min\": null, \"text\": \"Please enter a valid date.\", \"sum\": null, \"max\": null, \"type\": \"date_us\" }, \"id\": \"1047686867\", \"forced_ranking\": false } ], \"title\": \"Page 2\", \"position\": 2, \"id\": \"99241017\", \"question_count\": 1 } ], \"summary_url\": \"http://www.surveymonkey.com/summary/H5kuGlfExUEWdjnqay7jS_2FG_2FXK4n0pa_2FUS7uwvGGgOU_3D\", \"href\": \"https://api.surveymonkey.net/v3/surveys/29046621\", \"date_created\": \"2012-06-25T14:02:00\", \"collect_url\": \"http://www.surveymonkey.com/collect/list?sm=H5kuGlfExUEWdjnqay7jS_2FG_2FXK4n0pa_2FUS7uwvGGgOU_3D\", \"edit_url\": \"http://www.surveymonkey.com/create/?sm=H5kuGlfExUEWdjnqay7jS_2FG_2FXK4n0pa_2FUS7uwvGGgOU_3D\" }";

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
            Assert.AreEqual("29046621", survey.Id);
            Assert.AreEqual("Test Survey", survey.Title);
            Assert.AreEqual("en", survey.Language);
            Assert.AreEqual(DateTime.Parse("2012-06-25T14:02:00"), survey.Created);
            Assert.AreEqual(DateTime.Parse("2016-12-09T02:23:00"), survey.Modified);
        }
        
        [TestMethod]
        public void GetSurveyPages()
        {
            JObject surveyJObject = JObject.Parse(_surveyJSON);

            Survey survey = new Survey(surveyJObject);

            Assert.AreEqual(2, survey.Pages.Count);

            Assert.AreEqual("124139920", survey.Pages[0].Id);
            Assert.AreEqual("Page 1", survey.Pages[0].Title);
            Assert.AreEqual("", survey.Pages[0].Description);
            Assert.AreEqual(1, survey.Pages[0].Position);

            Assert.AreEqual("99241017", survey.Pages[1].Id);
            Assert.AreEqual("Page 2", survey.Pages[1].Title);
            Assert.AreEqual("Test Description", survey.Pages[1].Description);
            Assert.AreEqual(2, survey.Pages[1].Position);
        }
    }
}
