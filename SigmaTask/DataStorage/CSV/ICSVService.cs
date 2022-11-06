using System.Collections.Generic;

namespace SigmaTask.DataStorage.CSV
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>();
        void WriteCSVCollection<T>(List<T> records);
        void WriteCSVObject<T>(T record);
        bool IsFileExist();
        bool IsRecordExist();
    }
}
