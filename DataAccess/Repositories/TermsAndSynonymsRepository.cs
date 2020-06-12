using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddNewTermWithSynonyms(string term, string synonyms)
        {
            try
            {
                var termWithSynonyms = new TermWithSynonyms(term, synonyms);
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
