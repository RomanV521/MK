using AutoMapper;
using MK.DTO;
using MK.Models;

namespace MK.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Quote, QuoteCreateDto>().ReverseMap();
        CreateMap<Quote, QuoteUpdateDto>().ReverseMap();
        // Author
        CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<AuthorCreateDto, Author>();
        CreateMap<AuthorUpdateDto, Author>();
        CreateMap<Author, AuthorUpdateDto>();

        // Quote
        CreateMap<Quote, QuoteDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.TagNames, opt => opt.MapFrom(src => src.Tags.Select(t => t.Name).ToList()));
        CreateMap<QuoteCreateDto, Quote>();
        CreateMap<QuoteUpdateDto, Quote>();
        CreateMap<Quote, QuoteUpdateDto>()
            .ForMember(dest => dest.TagNames, opt => opt.MapFrom(src => src.Tags.Select(t => t.Name).ToList()));

        // Tag
        CreateMap<Tag, TagDto>();
        CreateMap<TagDto, Tag>();

        // User
        CreateMap<User, UserDto>();
    }
}