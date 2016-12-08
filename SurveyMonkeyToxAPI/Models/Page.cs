using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models
{
    public class Page
    {
        public Page(string id)
        {
            Id = id;

            Questions = new List<Question>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public int Position { get; set; }

        public IList<Question> Questions { get; set; }
    }
}
