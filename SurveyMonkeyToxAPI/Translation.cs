using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Helpers;
using SurveyMonkeyToxAPI.Models;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI
{
    public class Translation
    {
        private string _token;

        public Translation(string token)
        {
            _token = token;
        }

        public JArray GetSurveyxAPI(string surveyId)
        {
            if (!string.IsNullOrEmpty(_token))
            {
                string surveyJSON = SurveyMonkeyHelper.GetSurvey(_token, surveyId);
                string responseJSON = SurveyMonkeyHelper.GetResponses(_token, surveyId);

                return CreatexAPIStatements(surveyJSON, responseJSON);
            }
            else throw new Exception("A valid token has not been provided");
        }

        public JArray CreatexAPIStatements(string surveyJSON, string responseJSON)
        {
            JArray xAPIStatements = new JArray();
            
            // Create the survey from the passed JSON
            Survey survey = new Survey(surveyJSON);

            // Created the responses based on the passed JSON
            SurveyResponses surveyResponses = new SurveyResponses(responseJSON);

            // Get the questions where the email address for the user was pulled from
            IList<string> emailQuestionIds = surveyResponses.GetEmailQuestionIds();

            // get all the questions that are not an email address question
            IList<Question> questions = survey.GetValidQuestions(emailQuestionIds);

            // Get all the questions where an email for the user can be found
            IList<Response> responses = surveyResponses.GetAllValidResponses();

            // Generate the response xAPI
            for (int i = 0; i < responses.Count; i++)
            {
                foreach (Question question in questions)
                {
                    JObject questionResponse = responses[i].GetQuestion(question.Id);

                    JArray questionxAPIStatements = question.GetxAPIStatement(responses[i].Email, questionResponse);

                    foreach (JObject questionxAPIStatement in questionxAPIStatements)
                    {
                        xAPIStatements.Add(questionxAPIStatement);
                    }
                }

                // Add the survey xAPI
                xAPIStatements.Add(survey.GetxAPIStatement(responses[i]));
            }

            return xAPIStatements;
        }
    }
}
