using SigmaTask.DataStorage.CSV;
using SigmaTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace SigmaTask.Repositories
{
    public class CandidateRepo : ICandidateRepo
    {
        private readonly ICSVService CSVService;
        public CandidateRepo(ICSVService csvService)
        {
            CSVService = csvService;    
        }

        public List<Candidate> CandidateList()
        {
            return CSVService.CandidateList<Candidate>().ToList();
        }

        public Candidate SaveCandidate(Candidate candidate)
        {
            return CSVService.SaveCandidate(candidate);
        }
    }
}
