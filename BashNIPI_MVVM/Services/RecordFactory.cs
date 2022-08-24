using BashNIPI_MVVM.Model;

namespace BashNIPI_MVVM.Services
{
    public interface IRecordFactory
    {
        public Record CreateRecord(string name);
    }

    public class GoalFactory : IRecordFactory
    {
        public Record CreateRecord(string name)
        {
            return new Goal() { Name = name };
        }
    }

    public class DocumentFactory : IRecordFactory
    {
        public Record CreateRecord(string name)
        {
            return new Document() { Name = name };
        }
    }
}