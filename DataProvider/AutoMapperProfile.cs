using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data;

namespace DataProvider
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            IMappingExpression<DataRow, RecordsModel> mappingExpression;

            mappingExpression = CreateMap<DataRow, RecordsModel>();
            mappingExpression.DisableCtorValidation();
            mappingExpression.ForMember(d => d.id, o => o.MapFrom(s => s["id"])).ReverseMap();
            mappingExpression.ForMember(d => d.age, o => o.MapFrom(s => s["age"])).ReverseMap();
            mappingExpression.ForMember(d => d.workClass, o => o.MapFrom(s => s["WorkClass"])).ReverseMap();
            mappingExpression.ForMember(d => d.education, o => o.MapFrom(s => s["Education"])).ReverseMap();
            mappingExpression.ForMember(d => d.education_num, o => o.MapFrom(s => s["education_num"])).ReverseMap();
            mappingExpression.ForMember(d => d.martial_status, o => o.MapFrom(s => s["martial_status"])).ReverseMap();
            mappingExpression.ForMember(d => d.Occupation, o => o.MapFrom(s => s["Occupation"])).ReverseMap();
            mappingExpression.ForMember(d => d.Relationship, o => o.MapFrom(s => s["Relationship"])).ReverseMap();
            mappingExpression.ForMember(d => d.Race, o => o.MapFrom(s => s["Race"])).ReverseMap();
            mappingExpression.ForMember(d => d.Sex, o => o.MapFrom(s => s["Sex"])).ReverseMap();
            mappingExpression.ForMember(d => d.capital_gain, o => o.MapFrom(s => s["capital_gain"])).ReverseMap();
            mappingExpression.ForMember(d => d.capital_loss, o => o.MapFrom(s => s["capital_loss"])).ReverseMap();
            mappingExpression.ForMember(d => d.hours_week, o => o.MapFrom(s => s["hours_week"])).ReverseMap();
            mappingExpression.ForMember(d => d.country, o => o.MapFrom(s => s["Country"])).ReverseMap();
            mappingExpression.ForMember(d => d.over_50k, o => o.MapFrom(s => s["over_50k"])).ReverseMap();
        }
     


    }
}
