using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data;

namespace DataProvider
{
    public class DataRepository : IDataRepository
    {
        public CSVReader reader = new CSVReader(@"E:\USCensus.csv");
        public CsvWriter writer = new CsvWriter();
        public MapperConfiguration configuration;
        public IMapper _mapper;
        public DataRepository()
        {
            Initializer();
        }

        private void Initializer()
        {
            configuration = new MapperConfiguration(a => { a.AddProfile(new AutoMapperProfile()); });
            _mapper = configuration.CreateMapper();
           
        }

        public IEnumerable<RecordsModel> GetPersonRecords()
        {
            var records = reader.GetCachedCsvAsTable();
            var limitedRecords = records.AsEnumerable().Take(50);
            var recordsList = _mapper.Map<IEnumerable<DataRow>,List<RecordsModel>>(limitedRecords);
            return recordsList;
        }

        public void UpdateUserRecordById(RecordsModel recModel)
        {
            var csvTable = reader.GetOriginalCsvTable();
            var recordsToBeUpdated = csvTable.Select("Id = " + recModel.id.ToString()).FirstOrDefault();
            if (recordsToBeUpdated != null)
            {
                recordsToBeUpdated["age"] = recModel.age;
                recordsToBeUpdated["WorkClass"] = recModel.workClass;
                recordsToBeUpdated["Education"] = recModel.education;
                recordsToBeUpdated["education_num"] = recModel.education_num;
                recordsToBeUpdated["martial_status"] = recModel.martial_status;
                recordsToBeUpdated["Occupation"] = recModel.Occupation;
                recordsToBeUpdated["Relationship"] = recModel.Relationship;
                recordsToBeUpdated["Race"] = recModel.Race;
                recordsToBeUpdated["Sex"] = recModel.Sex;
                recordsToBeUpdated["capital_gain"] = recModel.capital_gain;
                recordsToBeUpdated["capital_loss"] = recModel.capital_loss;
                recordsToBeUpdated["hours_week"] = recModel.hours_week;
                recordsToBeUpdated["Country"] = recModel.country;
                recordsToBeUpdated["over_50k"] = recModel.over_50k;
            }
            var csvContent = writer.DataTableToCSV(csvTable);
            writer.SaveCsvToFile(csvContent, @"E: \USCensus.csv");
            
        }

        public RecordsModel GetPersonRecordById(int id)
        {
            var record = reader.GetCachedCsvAsTable().Select("Id = " + id.ToString()).FirstOrDefault();
            var personRecord = _mapper.Map<DataRow, RecordsModel>(record);
            return personRecord;
        }

        public IEnumerable<RecordsModel> GetPagedRecords(int lowerbound,int set)
        {
            var records = reader.GetCachedCsvAsTable();
            var limitedRecords = records.AsEnumerable().Skip(lowerbound).Take(set);
            var recordsList = _mapper.Map<IEnumerable<DataRow>, List<RecordsModel>>(limitedRecords);
            return recordsList;
        }
    }
}
