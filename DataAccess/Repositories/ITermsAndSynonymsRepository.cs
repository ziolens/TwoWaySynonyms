using System.Collections.Generic;
using Models;

namespace DataAccess.Repositories
{
    public interface ITermsAndSynonymsRepository
    {
        bool AddNewTermWithSynonyms(string term, string synonyms);

        IList<TermWithSynonyms> GetTermsWithSynonyms();
    }
}
