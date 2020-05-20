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
            CreateMap<PublisherBL, Publisher>().ReverseMap();
            CreateMap<ComicBookFilterModelBL, ComicBookFilterModel>().ReverseMap();
            CreateMap<OrderDetailsBL, OrderDetails>().ReverseMap();
            CreateMap<OrderFilterModelBL, OrderFilterModel>().ReverseMap();
            CreateMap<CartBL, Cart>().ReverseMap();

        }
    }
}
