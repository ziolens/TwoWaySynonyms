using System.Collections.Generic;
using DataAccess.Dtos;
using Models;

namespace DataAccess.Repositories
{
    public interface ITermsAndSynonymsRepository
    {
        bool AddNewTermWithSynonyms(TermWithSynonymsInput termWithSynonymsInput);

        IList<TermWithSynonyms> GetTermsWithSynonyms();
    }
}
