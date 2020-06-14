using System.Collections.Generic;

namespace TwoWaySynonyms.DataAccess.Dtos
{
    public class Words
    {
        public Words(string term, List<string> synonyms)
        {
            Term = term;
            Synonyms = synonyms;
        }

        public string Term { get; }

        public List<string> Synonyms { get; }
    }
}
