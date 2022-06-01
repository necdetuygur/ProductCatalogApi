using AutoMapper;

namespace Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //CreateMap<Category, GetAllCategoriesQueryResponse>().ReverseMap();
            //CreateMap<Category, GetAllCategoriesQueryResponse>();
            //CreateMap<Category, SearchCategoryQueryResponse>();
            //CreateMap<Category, SearchCategoryQueryResponse>().ReverseMap();
            //CreateMap<Category, GetByIdCategoryQueryResponse>();

            //CreateMap<Product, SearchProductQueryResponse>();

            #region Authentications
            //CreateMap<User, SignUpUserCommand>().ReverseMap();
            //CreateMap<User, UserViewModel>().ReverseMap();
            #endregion
        }
    }
}
