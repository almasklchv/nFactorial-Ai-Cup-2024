using AutoMapper;
using ExcelAI.Domain.Users;

namespace ExcelAI.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
