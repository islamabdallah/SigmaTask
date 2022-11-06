using SigmaTask.Models;
using System.Collections.Generic;

namespace SigmaTask.DataStorage.CSV
{
    public interface ICSVService
    {
        IEnumerable<T> CandidateList<T>();
        Candidate SaveCandidate(Candidate candidate);
    }
}
