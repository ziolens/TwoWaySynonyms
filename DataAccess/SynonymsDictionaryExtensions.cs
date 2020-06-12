using System.Collections.Generic;
using DataAccess.Dtos;

namespace DataAccess
{
    public static class SynonymsDictionaryExtensions
    {
        public static void TryToUpdateWithSynonymAsMainWord(
            this Dictionary<string, List<string>> sortedSynonyms,
            string term,
            string[] synonyms)
        {
            foreach (var synonym in synonyms)
            {
                if (sortedSynonyms.ContainsKey(synonym))
                {
                    sortedSynonyms.TryToUpdate(synonym, term);
                }
                else
                {
                    sortedSynonyms.Add(synonym, new List<string>
                    {
                        term
                    });
                }
            }
        }

        public static void TryToUpdate(
            this IReadOnlyDictionary<string, List<string>> sortedSynonyms,
            string mainWord,
            string similarWord)
        {
            if (sortedSynonyms[mainWord].Contains(similarWord))
            {
                return;
            }

            sortedSynonyms[mainWord].Add(similarWord);
        }

        public static List<Words> ToListOfWords(this Dictionary<string, List<string>> sortedSynonyms)
        {
            var words = new List<Words>();
            foreach (var combinedWord in sortedSynonyms)
            {
                words.Add(new Words(combinedWord.Key, combinedWord.Value));
            }

            return words;
        }
    }
}
