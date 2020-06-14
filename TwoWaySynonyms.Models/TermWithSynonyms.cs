using System.ComponentModel.DataAnnotations;

namespace TwoWaySynonyms.Models
{
    public class TermWithSynonyms
    {
        public TermWithSynonyms(string term, string synonyms)
        {
            Term = term;
            Synonyms = synonyms;
        }

        [Key]
        public int Id { get; private set; }

        public string Term { get; private set; }

        public string Synonyms { get; private set; }
    }
}
