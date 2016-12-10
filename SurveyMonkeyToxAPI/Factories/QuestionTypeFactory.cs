using Newtonsoft.Json.Linq;
using SurveyMonkeyToxAPI.Models;
using SurveyMonkeyToxAPI.Models.QuestionTypes;

namespace SurveyMonkeyToxAPI.Factories
{
    public static class QuestionTypeFactory
    {
        public static QuestionType GetQuestionType(string family, string subtype = "")
        {
            switch (family.Trim().ToLower())
            {
                case "single_choice":
                    switch (subtype.Trim().ToLower())
                    {
                        case "vertical":
                            return QuestionType.Single;
                    }
                    break;
                case "multiple_choice":
                    switch (subtype.Trim().ToLower())
                    {
                        case "vertical":
                            return QuestionType.Multiple;
                    }
                    break;
                case "matrix":
                    switch (subtype.Trim().ToLower())
                    {
                        case "single":
                            return QuestionType.MatrixSingle;
                        case "multiple":
                            return QuestionType.MatrixMultiple;
                        case "rating":
                            return QuestionType.MatrixRating;
                        case "ranking":
                            return QuestionType.MatrixRanking;
                    }
                    break;
                case "open_ended":
                    switch (subtype.Trim().ToLower())
                    {
                        case "single":
                        case "essay":
                            return QuestionType.OpenEndedSingle;
                        case "multi":
                            return QuestionType.OpenEndedMulti;
                        case "numerical":
                            return QuestionType.OpenEndedNumerical;
                    }
                    break;
                case "datetime":
                    return QuestionType.DateQuestion;
            }

            return QuestionType.Unknown;
        }

        public static IQuestionType GetQuestionTypeModule(QuestionType questionType, JObject questionData)
        {
            switch (questionType)
            {
                case QuestionType.Single:
                    return new Single(questionData);
                case QuestionType.Multiple:
                    return new Multiple(questionData);
                case QuestionType.MatrixSingle:
                    return new MatrixSingle(questionData);
                case QuestionType.MatrixMultiple:
                    return new MatrixMultiple(questionData);
                case QuestionType.MatrixRating:
                    return new MatrixRating(questionData);
                case QuestionType.MatrixRanking:
                    return new MatrixRanking(questionData);
                case QuestionType.OpenEndedSingle:
                    return new OpenEndedSingle(questionData);
                case QuestionType.OpenEndedMulti:
                    return new OpenEndedMulti(questionData);
                case QuestionType.OpenEndedNumerical:
                    return new OpenEndedNumerical(questionData);
                case QuestionType.DateQuestion:
                    return new DateQuestion(questionData);
            }

            return null;
        }
    }
}
