using AutoMapper;
using Thi.Models;

namespace Thi.MappingProfile
{
    public class ReportTableMapping : Profile
    {
        public ReportTableMapping()
        {
            CreateMap<RetalDetails, ReportTableMapping>();
        }
    }
}
