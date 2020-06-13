using System.Collections.Generic;
using System.Linq;
using DataAccess.Dtos;
using Models;

namespace DataAccess.Mappers
{
    public class SynonymsMapper
    {
        public static IEnumerable<Words> Map(IEnumerable<TermWithSynonyms> termsWithSynonyms)
        {
            var sortedSynonyms = new Dictionary<string, List<string>>();
            foreach (var termWithSynonyms in termsWithSynonyms)
            {
                var term = termWithSynonyms.Term;
                var synonyms = termWithSynonyms.Synonyms.Split(',');
                if (!sortedSynonyms.ContainsKey(term))
                {
                    sortedSynonyms.Add(term, synonyms.ToList());
                    sortedSynonyms.TryToUpdateWithSynonymAsMainWord(term, synonyms);
                }
                else
                {
                    foreach (var synonym in synonyms)
                    {
                        sortedSynonyms.TryToUpdate(term, synonym);
                    }

                    sortedSynonyms.TryToUpdateWithSynonymAsMainWord(term, synonyms);
                }
            }

            return sortedSynonyms.ToListOfWords();
        }

        public static TermWithSynonyms Map(TermWithSynonymsInput termWithSynonymsInput)
        {
            return new TermWithSynonyms(termWithSynonymsInput.Term, termWithSynonymsInput.Synonyms);
        }
    }
}
