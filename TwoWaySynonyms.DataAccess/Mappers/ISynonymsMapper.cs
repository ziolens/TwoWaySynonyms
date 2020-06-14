using System.Collections.Generic;
using TwoWaySynonyms.DataAccess.Dtos;
using TwoWaySynonyms.Models;

namespace TwoWaySynonyms.DataAccess.Mappers
{
    public interface ISynonymsMapper
    {
        IEnumerable<Words> Map(IEnumerable<TermWithSynonyms> termsWithSynonyms);

        TermWithSynonyms Map(TermWithSynonymsInput termWithSynonymsInput);
    }
}
