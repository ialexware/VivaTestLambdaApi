using AutoMapper;
using VivaTestLambdaApi.Contracts.Dto;
using VivaTestLambdaApi.Contracts.Models;
using VivaTestLambdaApi.Contracts.Request;

namespace VivaTestLambdaApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();

                config.CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();



                config.CreateMap<UpdateProductRequest, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
