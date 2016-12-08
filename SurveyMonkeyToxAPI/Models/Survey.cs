using System;
using System.Collections.Generic;

namespace SurveyMonkeyToxAPI.Models
{
    public class Survey
    {
        public Survey(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Language { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public IList<Page> Pages { get; set; }
    }
}
