using System.Collections.ObjectModel;
using Data.Context;
using DTOs.Likes;
using Like.Service.interfa;
using Microsoft.EntityFrameworkCore;
using Model.Likes;
using Models.User;
using Services.GeneralServise;

namespace Services.LikesService;
 


 public class LikesService:ILikesService {


    private readonly DataDbContext _dbContext;
    private readonly IGeneralServices _generalService;

    public LikesService(DataDbContext dbContext, IGeneralServices generalServices){
        _dbContext = dbContext;
        _generalService = generalServices;
    }
    public async Task<string> CreateLike (LikesDto requestBody){


   var  userLikedPost = await _dbContext.Likes
        .SingleOrDefaultAsync(l => l.PostId == requestBody.PostId && l.UserId == requestBody.UserId);


        if(userLikedPost != null){
                _dbContext.Likes.Remove( userLikedPost );
        await _dbContext.SaveChangesAsync();

        return "Like has been removed";
        }

        var newLike = _generalService.ConvertDtoToModel<LikesDto, LikesModel>(requestBody);

        await _dbContext.AddAsync(newLike);
        await _dbContext.SaveChangesAsync();

        return "Like has been added";
    }

    // public async Task<List<UserModel>> GetPostLikes(){
    //   var users = await _dbContext.Users 
    //     .Select(u => new UserModel
    //     {
    //         Id = u.Id,
    //         UserName = u.UserName,
    //         Avatar = u.Avatar ?? "DefaultAvatar"
    //     })
    //     .ToListAsync();

    // return users;
    // }  
 }