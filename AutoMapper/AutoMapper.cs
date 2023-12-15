using AutoMapper;
using DTOs.Post;
using Model.Posts;

namespace AutoMapper;



public class AutoMapperProfile : Profile{

    public AutoMapperProfile(){

        CreateMap<PostDto, PostModel>();
    }
}