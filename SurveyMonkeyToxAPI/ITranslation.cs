using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI
{
    public interface ITranslation
    {
        JArray GetxAPIStatements(string surveyId);
    }
}
