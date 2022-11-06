using SigmaTask.Models;
using SigmaTask.Repositories;
using Xunit;


namespace SigmaUnitTesting
{
    public class CandidateTest
    {
        private readonly ICandidateRepo CandidateRepo;
        public CandidateTest(ICandidateRepo candidateRepo)
        {
            CandidateRepo = candidateRepo;
        }

        [Fact]
        public void GetCandidateList()
        {
            //act
            var _candidateList = CandidateRepo.CandidateList();
            //assert
            Assert.Equal(3, _candidateList.Count);
        }

        [Fact]
        public void SaveCandidate()
        {
            //arrange
            Candidate _candidate = new Candidate()
            {
                Email = "Candidate@Sigma.com",
                FirstName = "First",
                LastName = "Last",
                GitHub = "GitHub",
                Linkedin = "Linkedin",
                PhoneNumber = "2100015655",
                TimeInterval = "3-4",
                Comment = "Comment"
            };

            //act
            var _result = CandidateRepo.SaveCandidate(_candidate);

            //assert
            Assert.Equal(_candidate, _result);
        }
    }
}
