using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public interface IQuestionType
    {
        string GetVerb();

        JObject GetReadableVerb();

        JObject GetResultxAPI(JObject questionResponse);
    }
}
