using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Factories;
using SurveyMonkeyToxAPI.Models.QuestionTypes;
using System;
using System.Collections.Generic;

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
        // Definitely needs some work
        public JArray GetxAPIStatement(string email, JObject questionResponse)
        {
            JArray returnxAPI = new JArray();

            if (QuestionModule.IsGrouped())
            {
                JObject groupedResponse = QuestionModule.GetResultxAPI(questionResponse);

                Dictionary<string, int> responseCount = new Dictionary<string, int>();
                bool containsMutliChoice = false;

                foreach (JObject question in (JArray)groupedResponse["questions"])
                {
                    if (!responseCount.ContainsKey((string)question["id"])) responseCount[(string)question["id"]] = 1;
                    else
                    {
                        responseCount[(string)question["id"]]++;
                        containsMutliChoice = true;
                    }
                }

                if (containsMutliChoice)
                {
                    Dictionary<string, JObject> responses = new Dictionary<string, JObject>();

                    foreach (string key in responseCount.Keys)
                    {
                        foreach (JObject question in (JArray)groupedResponse["questions"])
                        {
                            if (key == (string)question["id"])
                            {
                                if (!responses.ContainsKey(key))
                                {
                                    responses[key] = new JObject();
                                    responses[key]["extensions"] = new JObject();
                                }

                                responses[key]["extensions"][(string)question["answer_id"]] = (string)question["response"];
                            }
                        }
                    }

                    foreach (string key in responses.Keys)
                    {
                        string questionText = Heading;

                        foreach (JObject question in (JArray)groupedResponse["questions"])
                        {
                            if ((key == (string)question["id"]) && (!string.IsNullOrEmpty((string)question["text"])))
                            {
                                questionText = (string)question["text"];
                                break;
                            }
                        }

                        returnxAPI.Add(CreatexAPIStatement(email, questionText, responses[key]));
                    }
                }
                else
                {
                    foreach (JObject question in (JArray)groupedResponse["questions"])
                    {
                        string questionText = Heading;
                        if (!string.IsNullOrEmpty((string)question["text"])) questionText = (string)question["text"];

                        JObject response = new JObject();
                        response["response"] = (string)question["response"];

                        returnxAPI.Add(CreatexAPIStatement(email, questionText, response));
                    }
                }

                foreach (JObject responseStatement in returnxAPI)
                {
                    responseStatement["grouping"] = new JObject();
                    responseStatement["grouping"]["id"] = (string)groupedResponse["id"];
                    responseStatement["grouping"]["objectType"] = "Activity";
                    responseStatement["grouping"]["definition"] = new JObject();
                    responseStatement["grouping"]["definition"]["name"] = new JObject();
                    responseStatement["grouping"]["definition"]["name"]["en"] = Heading;
                    responseStatement["grouping"]["definition"]["name"]["type"] = "http://adlnet.gov/expapi/activities/question";
                }
            }
            else
            {
                returnxAPI.Add(CreatexAPIStatement(email, Heading, QuestionModule.GetResultxAPI(questionResponse)));
            }
            
            return returnxAPI;
        }

        #endregion

        #region Private Methods

        private JObject CreatexAPIStatement(string email, string questionText, JObject questionResponse)
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
            questionxAPI["verb"]["id"] = QuestionModule.GetVerb();
            questionxAPI["verb"]["display"] = QuestionModule.GetReadableVerb();

            questionxAPI["result"] = questionResponse;

            // add details about the question
            questionxAPI["object"] = new JObject();
            questionxAPI["object"]["id"] = Id;
            questionxAPI["object"]["objectType"] = "Activity";
            questionxAPI["object"]["definition"] = new JObject();
            questionxAPI["object"]["definition"]["name"] = new JObject();
            questionxAPI["object"]["definition"]["name"]["en-US"] = questionText;
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
