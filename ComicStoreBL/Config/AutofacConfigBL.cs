using Autofac;
using ComicStoreBL.Models;
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

            //builder.RegisterType<FilterImplementation>()
            //        .As<IFilter<ComicBook>>()
            //        .WithParameter(new TypedParameter(typeof(FilterInputBL), "filter"));

        }
    }
}
