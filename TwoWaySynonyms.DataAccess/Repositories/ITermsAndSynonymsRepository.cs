using System.Collections.Generic;
using TwoWaySynonyms.DataAccess.Dtos;

namespace TwoWaySynonyms.DataAccess.Repositories
{
    public interface ITermsAndSynonymsRepository
    {
        bool AddNewTermWithSynonyms(TermWithSynonymsInput termWithSynonymsInput);

        IEnumerable<Words> GetTermsWithSynonyms();
    }
}
