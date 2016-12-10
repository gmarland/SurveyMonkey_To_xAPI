using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI.Models.QuestionTypes
{
    public interface IQuestionType
    {
        JObject GetResultxAPI(Response response);
    }
}
