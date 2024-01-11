using AutoMapper;

namespace Services.GeneralServise;
 

 public class GeneralServices : IGeneralServices { 
       public   TDestination ConvertDtoToModel<TSource, TDestination>(TSource dto) where TSource : class
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
        var mapper = new Mapper(config);

        return mapper.Map<TSource, TDestination>(dto);
    }


 }