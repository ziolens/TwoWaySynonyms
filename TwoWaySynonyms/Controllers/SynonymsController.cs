using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TwoWaySynonyms.DataAccess.Dtos;
using TwoWaySynonyms.DataAccess.Repositories;

namespace TwoWaySynonyms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SynonymsController : ControllerBase
    {
        private readonly ITermsAndSynonymsRepository _termsAndSynonymsRepository;

        public SynonymsController(ITermsAndSynonymsRepository termsAndSynonymsRepository)
        {
            _termsAndSynonymsRepository = termsAndSynonymsRepository;
        }

        [HttpPost]
        [Route("add-new")]
        public ActionResult AddNewTermWithSynonyms([FromBody] TermWithSynonymsInput termWithSynonyms)
        {
            var result = _termsAndSynonymsRepository.AddNewTermWithSynonyms(termWithSynonyms);
            if (result)
            {
                return Ok();
            }

            return StatusCode(500, "Adding new term with synonyms failed");
        }

        [HttpGet]
        [Route("get-terms-with-synonyms")]
        public ActionResult<List<Words>> GetTermsWithSynonyms()
        {
            var termsWithSynonyms = _termsAndSynonymsRepository.GetTermsWithSynonyms();
            if (!termsWithSynonyms.Any())
            {
                return NoContent();
            }

            return Ok(termsWithSynonyms);
        }
    }
}
