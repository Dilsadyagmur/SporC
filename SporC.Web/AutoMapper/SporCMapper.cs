using AutoMapper;
using SporC.Entities.Concrete;
using SporC.Web.Models.DTO_s;

namespace SporC.Web.AutoMapper
{
    public class SporCMapper : Profile
    {
        public SporCMapper() 
        {
            CreateMap<CommentCreateDTO, Comment>();
            CreateMap<PostcreateDTO, Post>();

        }

    }
}
