using Newtonsoft.Json.Linq;

namespace SurveyMonkeyToxAPI
{
    public class Translation
    {
        private string _token;

        public Translation(string token)
        {
            _token = token;
        }

        public JArray GetxAPIStatements(string surveyId)
        {
            JArray xAPIStatements = new JArray();



            return xAPIStatements;
        }
    }
}
