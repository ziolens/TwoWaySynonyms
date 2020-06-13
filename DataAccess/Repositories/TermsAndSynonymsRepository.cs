using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Dtos;
using DataAccess.Mappers;
using Models;

namespace DataAccess.Repositories
{
    public class TermsAndSynonymsRepository : ITermsAndSynonymsRepository
    {
        private readonly Func<ApplicationDbContext> _applicationDbContextFactory;

        public TermsAndSynonymsRepository(Func<ApplicationDbContext> applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public bool AddNewTermWithSynonyms(TermWithSynonymsInput termWithSynonymsInput)
        {
            try
            {
                var termWithSynonyms = SynonymsMapper.Map(termWithSynonymsInput);
                using (var applicationDbContext = _applicationDbContextFactory())
                {
                    applicationDbContext.Add(termWithSynonyms);
                    applicationDbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public IList<TermWithSynonyms> GetTermsWithSynonyms()
        {
            try
            {
                using (var applicationDbContext = _applicationDbContextFactory())
                {
                    return applicationDbContext.TermsWithSynonyms.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<TermWithSynonyms>();
            }

        }
    }
}
