using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace DataService
{
    public class PersonRecordServices : IPersonRecordServices
    {
        public IDataRepository _context;
        public PersonRecordServices(IDataRepository context)
        {
            _context = context;
        }

        public IEnumerable<RecordsModel> GetLimitedUSPersonRecords(int lowerBound, int limit)
        {
            return _context.GetPagedRecords(lowerBound,limit);
        }

        public IEnumerable<RecordsModel> GetUSPersonRecords()
        {
            return _context.GetPersonRecords();
        }

        public RecordsModel GetUSPersonRecordbyId(int id)
        {
            return _context.GetPersonRecordById(id);
        }

        public void UpdateUserRecord(RecordsModel recModel)
        {
            _context.UpdateUserRecordById(recModel);
        }
    }

    public interface IPersonRecordServices
    {
        IEnumerable<RecordsModel> GetUSPersonRecords();
        IEnumerable<RecordsModel> GetLimitedUSPersonRecords(int lowerBound, int limit);
        void UpdateUserRecord(RecordsModel recModel);
        RecordsModel GetUSPersonRecordbyId(int id);
    }
}
