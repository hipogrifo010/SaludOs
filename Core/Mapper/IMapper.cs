using ApiSalud.Core.Models.DTO;
using ApiSalud.Entities;
using AutoMapper;

namespace ApiSalud.Core.Mapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}