using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Helpers.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetCategoryDto, Category>().ReverseMap();
        CreateMap<GetAllCategoryDto, Category>().ReverseMap();
        CreateMap<AddCategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
    }
}