using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using SigmaTask.Models;
using System.Linq;

namespace SigmaTask.DataStorage.CSV
{
    public class CSVService : ICSVService
    {
        private readonly IWebHostEnvironment HostEnvironment;
        private StreamReader Reader;
        private CsvReader CSVReader;

        public CSVService(IWebHostEnvironment hostEnvironment)
        {
            HostEnvironment = hostEnvironment;
        }
        public IEnumerable<T> CandidateList<T>()
        {
            if (IsFileExist())
            {
                Reader = new StreamReader(HostEnvironment.WebRootPath + ServerPath.CandidateCSVFilePath);
                CSVReader = new CsvReader(Reader, CultureInfo.InvariantCulture);
                var records = CSVReader.GetRecords<T>();
                return records;
            }
            return null;
        }
        public Candidate SaveCandidate(Candidate candidate)
        {
            if (candidate != null)
            {
                var _candidates = ReadCSV<Candidate>().ToList();
                var _candidateExist = _candidates.Where(r => r.Email.Contains(candidate.Email)).FirstOrDefault();

                //Case #1 Candidate Exist (Update Operation)
                if (_candidateExist != null)
                {
                    _ = _candidates.Where(c => c.Email.Contains(candidate.Email)).Select(c =>
                    {
                        c.FirstName = candidate.FirstName;
                        c.LastName = candidate.LastName;
                        c.PhoneNumber = candidate.PhoneNumber;
                        c.TimeInterval = candidate.TimeInterval;
                        c.Linkedin = candidate.Linkedin;
                        c.GitHub = candidate.GitHub;
                        c.Comment = candidate.Comment;
                        return c;
                    }).ToList();

                    Reader.Close();
                    CSVReader.Dispose();
                    WriteCSVCollection(_candidates);
                }
                //Case #2 Candidate Not Exist (Add Operation)
                else
                {
                    Reader.Close();
                    CSVReader.Dispose();
                    WriteCSVObject(candidate);
                }
            }
            return candidate;
        }
        private bool IsFileExist()
        {
            if (File.Exists(HostEnvironment.WebRootPath + ServerPath.CandidateCSVFilePath))
                return true;
            return false;
        }
        private void WriteCSVCollection<T>(List<T> records)
        {
            if (IsFileExist())
            {
                using var writer = new StreamWriter(HostEnvironment.WebRootPath + ServerPath.CandidateCSVFilePath);
                using var CSVWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                CSVWriter.WriteRecords(records);
                CSVWriter.Dispose();
            }
        }
        private void WriteCSVObject<T>(T record)
        {
            if (IsFileExist())
            {
                // Append to the file.
                var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false, };
                using var stream = File.Open(HostEnvironment.WebRootPath + ServerPath.CandidateCSVFilePath, FileMode.Append);
                using var writer = new StreamWriter(stream);
                using var csv = new CsvWriter(writer, config);
                csv.WriteRecords((System.Collections.IEnumerable)record);
            }
        }
    }
}
