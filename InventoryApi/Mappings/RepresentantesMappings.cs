using AutoMapper;
using InventotyClass;
using Models;

namespace Inventory.Mappings
{
    public class RepresentantesProfile : Profile
    {
        public RepresentantesProfile()
        {
            CreateMap<GetAllRepresentantes, Representantes>().ReverseMap();
            CreateMap<PostRepresentantes, Representantes>().ReverseMap();
        }
    }
}