using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI
{
    public interface ITranslation
    {
        JArray GetSurveyxAPI(string surveyId);
    }
}