using ComicStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>
    {
        public PublisherRepository(ComicStoreContext context) : base(context) { } 
    }
}
