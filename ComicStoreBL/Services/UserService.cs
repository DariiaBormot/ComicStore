using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Services
{
    public class UserService : GenericService<UserBL, User>, IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override UserBL Map(User entity)
        {
            return _mapper.Map<UserBL>(entity);
        }

        public override User Map(UserBL blmodel)
        {
            return _mapper.Map<User>(blmodel);
        }

        public override IEnumerable<UserBL> Map(IList<User> entities)
        {
            return _mapper.Map<IEnumerable<UserBL>>(entities);
        }

        public override IEnumerable<User> Map(IList<UserBL> models)
        {
            return _mapper.Map<IEnumerable<User>>(models);
        }
    }
}
