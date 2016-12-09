using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models
{
    public class Page
    {
        public Page(JObject pageJObject)
        {
            PopulatePage(pageJObject);
        }

        private void PopulatePage(JObject pageJObject)
        {
            if (pageJObject["id"] != null) Id = (string)pageJObject["id"];
            else throw new Exception("A page id could not be found");

            if (pageJObject["title"] != null) Title = (string)pageJObject["title"];
            else throw new Exception("A page title could not be found");

            if (pageJObject["description"] != null) Description = (string)pageJObject["description"];
            else throw new Exception("A page description could not be found");

            if (pageJObject["position"] != null) Position = (int)pageJObject["position"];
            else throw new Exception("A page position could not be found");
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Position { get; set; }

        public IList<Question> Questions { get; set; }
    }
}
