using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ComicStoreBL.Config;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.App_Start
{
    public class AutofacConfigMVC
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                 new List<Profile>() { new WebAutomapperProfile(), new AutoMapperProfileBL() }));
            builder.Register(c => config.CreateMapper());

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ComicBookService>().As<IComicBookService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<PublisherService>().As<IPublisherService>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterModule<AutofacConfigBL>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}