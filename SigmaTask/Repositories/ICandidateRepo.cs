using SigmaTask.Models;
using System.Collections.Generic;

namespace SigmaTask.Repositories
{
    public interface ICandidateRepo
    {
        List<Candidate> CandidateList();
        Candidate GetCandidate(string email);
        Candidate SaveCandidate(Candidate candidate);
    }
}
