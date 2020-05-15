using AutoMapper;
using ComicStoreBL.Models;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<CategoryBL, CategoryViewModel>().ReverseMap();
            CreateMap<ComicBookBL, ComicBookViewModel>().ReverseMap();
            CreateMap<OrderBL, OrderViewModel>().ReverseMap();
            CreateMap<PublisherBL, PublisherViewModel>().ReverseMap();
            CreateMap<OrderDetailsBL, ShippingDetailsViewModel>().ReverseMap();
            CreateMap<FilterInputBL, FilterModel>().ReverseMap();
            CreateMap<ShippingDetailsBL, ShippingDetailsViewModel>().ReverseMap(); 
            CreateMap<OrderDetailsBL, OrderDetailsViewModel>().ReverseMap();

        }
    }
}