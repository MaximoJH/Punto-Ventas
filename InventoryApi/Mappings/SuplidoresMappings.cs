using AutoMapper;
using InventotyClass;
using Models;

namespace Inventory.Mappings
{
    public class SuplidoresProfile : Profile
    {
        public SuplidoresProfile()
        {
            CreateMap<Suplidores, GetAllSuplidores>().ReverseMap();
            CreateMap<Suplidores, PostSuplidores>().ReverseMap();
        }
    }
}