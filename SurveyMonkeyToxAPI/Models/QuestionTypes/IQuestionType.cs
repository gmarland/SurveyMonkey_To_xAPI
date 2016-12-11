using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public interface IQuestionType
    {
        bool IsGrouped();

        string GetVerb();

        JObject GetReadableVerb();

        JObject GetResultxAPI(JObject questionResponse);
    }
}
