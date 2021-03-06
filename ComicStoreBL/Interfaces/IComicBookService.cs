﻿using ComicStoreBL.Models;
using ComicStoreDAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Interfaces
{
    public interface IComicBookService : IGenericService<ComicBookBL>
    {
        IEnumerable<ComicBookBL> GetBooksByFilter(ComicBookFilterModelBL filter); 
        int CountPageItems(ComicBookFilterModelBL filter); 
    }
}
