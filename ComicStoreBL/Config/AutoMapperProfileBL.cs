using AutoMapper;
using ComicStoreBL.Models;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Config
{
    public class AutoMapperProfileBL : Profile
    {
        public AutoMapperProfileBL()
        {
            CreateMap<CategoryBL, Category>().ReverseMap();
            CreateMap<ComicBookBL, ComicBook>().ReverseMap();
            CreateMap<OrderBL, Order>().ReverseMap();
            CreateMap<UserBL, User>().ReverseMap();
            CreateMap<PublisherBL, Publisher>().ReverseMap();
            CreateMap<FilterInputBL, FilterInputDAL>().ReverseMap();

        }
    }
}
