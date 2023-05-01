using AutoMapper;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.DTOs.TodoItems;

namespace TodoBoardApplication.AutoMapperProfiles
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItem, TodoItemDto>()
                .ForMember(dest => dest.Colour, src => src.MapFrom(e => e.Colour.ToString()))
                .ForMember(dest => dest.Category, src => src.MapFrom(e => e.Category.ToString()))
                .ForMember(dest => dest.MD5Hash, src => src.MapFrom(e => e.GetMD5Hash()));
            CreateMap<TodoItemComment, TodoItemCommentDto>();
        }
    }
}
