using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigmaTask.Models;
using SigmaTask.Repositories;
using System.Threading.Tasks;

namespace SigmaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepo CandidateRepo;
        public CandidateController(ICandidateRepo candidateRepo)
        {
            CandidateRepo = candidateRepo;
        }

        [HttpGet("CandidateList")]
        public IActionResult GetCandidateList()
        {
            return Ok(CandidateRepo.CandidateList());
        }

        [HttpPost("SaveCandidate")]
        public IActionResult SaveCandidate(Candidate candidate)
        {
            return Ok(CandidateRepo.SaveCandidate(candidate));
        }
    }
}
