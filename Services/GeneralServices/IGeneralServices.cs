namespace Services.GeneralServise;


public interface IGeneralServices
{
    TDestination ConvertDtoToModel<TSource, TDestination>(TSource dto) where TSource : class;

}