using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public interface IQuestionType
    {
        bool IsMatrix();

        string GetVerb();

        JObject GetReadableVerb();

        JObject GetResultxAPI(JObject questionResponse);
    }
}
