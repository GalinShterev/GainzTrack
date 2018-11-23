using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string GetIdentityIdWithUsername(string username)
        {
            var identityUser = _context.Users.FirstOrDefault(x => x.UserName == username);

            return identityUser.Id;
        }
    }
}
