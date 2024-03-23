using AutoMapper;
using Bookify.Web.Core.ViewModels;

namespace Bookify.Web.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryFormViewModel, Category>();
        }
    }
}
