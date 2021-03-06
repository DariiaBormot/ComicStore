﻿using Autofac;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreBL.Services;
using ComicStoreDAL;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Filters;
using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Config
{
    public class AutofacConfigBL : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<ComicStoreContext>().InstancePerRequest();
            builder.RegisterType<CartRepository>().As<ICartRepository>();
            builder.RegisterType<CartService>().As<ICartService>();

        }
    }
}
