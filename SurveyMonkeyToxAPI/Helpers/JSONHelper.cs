using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Helpers
{
    public static class JSONHelper
    {
        public static JObject DictionaryToJSON(IDictionary<string, string> dictionary)
        {
            JObject returnJSON = new JObject();

            foreach (string key in dictionary.Keys)
            {
                returnJSON[key] = dictionary[key];
            }

            return returnJSON;
        }
    }
}
