using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public interface IDataRepository
    {
        IEnumerable<RecordsModel> GetPersonRecords();

        void UpdateUserRecordById(RecordsModel recModel);

        RecordsModel GetPersonRecordById(int id);

        IEnumerable<RecordsModel> GetPagedRecords(int lowerbound, int set);
    }
}
