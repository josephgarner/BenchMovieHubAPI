using AutoMapper;
using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;
using MovieHubAPI.domain.Response;

namespace MovieHubAPI.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>();

        CreateMap<MovieDto, MovieSummaryResponse>();
        CreateMap<MovieDto, MovieResponse>();
    }
}