using System;
using System.Collections.Generic;
using System.Linq;
using TwoWaySynonyms.DataAccess.Dtos;
using TwoWaySynonyms.DataAccess.Mappers;
using TwoWaySynonyms.Models;

namespace TwoWaySynonyms.DataAccess.Repositories
{
    public class TermsAndSynonymsRepository : BaseRepository, ITermsAndSynonymsRepository
    {
        private readonly Func<ApplicationDbContext> _applicationDbContextFactory;
        private readonly ISynonymsMapper _synonymsMapper;

        public TermsAndSynonymsRepository(Func<ApplicationDbContext> applicationDbContextFactory, ISynonymsMapper synonymsMapper)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
            _synonymsMapper = synonymsMapper;
        }

        public bool AddNewTermWithSynonyms(TermWithSynonymsInput termWithSynonymsInput)
        {
            return ExecuteDbOperation(() =>
            {
                var termWithSynonyms = _synonymsMapper.Map(termWithSynonymsInput);
                using (var applicationDbContext = _applicationDbContextFactory())
                {
                    applicationDbContext.Add(termWithSynonyms);
                    applicationDbContext.SaveChanges();
                }

                return true;
            });
        }

        public IEnumerable<Words> GetTermsWithSynonyms()
        {
            return ExecuteDbOperation(() =>
            {
                using (var applicationDbContext = _applicationDbContextFactory())
                {
                    var termsWithSynonyms = applicationDbContext.TermsWithSynonyms.ToList();
                    return _synonymsMapper.Map(termsWithSynonyms);
                }
            });
        }
    }
}
