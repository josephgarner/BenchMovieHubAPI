using AutoMapper;
using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;

namespace MovieHubAPI.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<MovieReview, ReviewDto>();
        CreateMap<ReviewDto, MovieReview>();
    }
}