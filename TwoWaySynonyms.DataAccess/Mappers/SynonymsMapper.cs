using System.Collections.Generic;
using System.Linq;
using TwoWaySynonyms.DataAccess.Dtos;
using TwoWaySynonyms.Models;

namespace TwoWaySynonyms.DataAccess.Mappers
{
    public class SynonymsMapper : ISynonymsMapper
    {
        private const char SynonymsSeparator = ',';

        public IEnumerable<Words> Map(IEnumerable<TermWithSynonyms> termsWithSynonyms)
        {
            var words = new List<Words>();
            foreach (var termWithSynonyms in termsWithSynonyms)
            {
                var term = termWithSynonyms.Term;
                var synonyms = termWithSynonyms.Synonyms.Split(SynonymsSeparator).ToList();
                words.Add(new Words(term, synonyms));

                foreach (var synonym in synonyms)
                {
                    words.Add(new Words(synonym, new List<string>
                    {
                        term
                    }));
                }
            }

            var sortedWords = words.GroupBy(w => w.Term, w => w.Synonyms)
                .SelectMany(group => new List<Words>
                {
                    new Words(group.Key, group.SelectMany(synonyms => synonyms).Distinct().ToList())
                });

            return sortedWords;
        }

        public TermWithSynonyms Map(TermWithSynonymsInput termWithSynonymsInput)
        {
            return new TermWithSynonyms(termWithSynonymsInput.Term, termWithSynonymsInput.Synonyms);
        }
    }
}
