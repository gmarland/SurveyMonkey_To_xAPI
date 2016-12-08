﻿using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Factories;
using SurveyMonkeyToxAPI.Models.QuestionTypes;
using System;

namespace SurveyMonkeyToxAPI.Models
{
    public class Question
    {
        public Question(JObject questionData)
        {
            Heading = GetHeading(questionData);

            Position = GetPosition(questionData);

            QuestionType = GetQuestionType(questionData);

            QuestionModule = QuestionTypeFactory.GetQuestionTypeModule(QuestionType, questionData);
        }

        public string Heading { get; set; }

        public int Position { get; set; }

        public QuestionType QuestionType { get; set; }

        public IQuestionType QuestionModule { get; set; }

        private string GetHeading(JObject questionData)
        {
            if (questionData["headings"] != null)
            {
                JArray headings = (JArray)questionData["headings"];

                if (headings.Count > 0) return headings.First.ToString();
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
    }
}
