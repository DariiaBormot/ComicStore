﻿using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Repositories
{
    public class ComicBookRepository : GenericRepository<ComicBook>
    {
        public ComicBookRepository(ComicStoreContext context) : base(context) { }
    }
}
