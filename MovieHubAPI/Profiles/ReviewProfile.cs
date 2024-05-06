using AutoMapper;
using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;
using MovieHubAPI.domain.Response;

namespace MovieHubAPI.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<MovieReview, ReviewDto>();
        CreateMap<ReviewDto, MovieReview>();

        CreateMap<ReviewResponse, ReviewDto>();
        CreateMap<ReviewDto, ReviewResponse>();
    }
}