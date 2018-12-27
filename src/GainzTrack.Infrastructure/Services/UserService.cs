using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Data;
using GainzTrack.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        public string GetIdentityIdByUsername(string username)
        {
            var identityUser = _repository.GetBy<IdentityApplicationUser>(x=>x.UserName == username);
            return identityUser.Id;
        }

        public MainUser GetMainUserByIdentityId(string identityId)
        {
           return  _repository
                .GetBy<MainUser>(new MainUserByIdentityId(identityId));
        }

        public MainUser GetMainUserByUsername(string username)
        {
            return _repository.GetBy<MainUser>(b => b.Username == username);
        }
    }
}
