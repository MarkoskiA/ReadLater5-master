using AutoMapper;
using Contracts.DTOs;
using Contracts.Request;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class BookmarkProfile : Profile
    {
        //Adding mapping rules so the mapper knows how to convert the object
        public BookmarkProfile()
        {
            CreateMap<Bookmark, BookmarkDto>(); 
            CreateMap<BookmarkRequest, Bookmark>();
        }
    }
}
