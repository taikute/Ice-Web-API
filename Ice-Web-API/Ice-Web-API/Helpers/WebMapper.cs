using AutoMapper;
using Ice_Web_API.Data;
using Ice_Web_API.Models;

namespace Ice_Web_API.Helpers
{
    public class WebMapper : Profile
    {
        public WebMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
