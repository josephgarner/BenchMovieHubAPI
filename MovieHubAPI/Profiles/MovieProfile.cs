using AutoMapper;
using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;

namespace MovieHubAPI.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<Movie, MovieSummaryDto>();
    }
}