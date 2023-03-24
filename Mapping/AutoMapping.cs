using Assesment.DTO;
using Assesment.Model;
using AutoMapper;

namespace Assesment.Mapping
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee,UpdateEmployee>().ReverseMap();
        }
          


    }
}
