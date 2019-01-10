using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Data;
using GainzTrack.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
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

        public string GetAvatar(string username)
        {
            var imgPath = this.GetMainUserByUsername(username).AvatarPath;

            if(imgPath == "Default")
            {
                return Path.Combine("Avatars", "Default", "default.jpg");
            }

            var fileName = Path.GetFileName(Directory.GetFiles(imgPath).First());

            return Path.Combine("Avatars", username, fileName);
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
        public MainUser GetMainUserByUsernameWithIncludes(string username)
        {
            var expression = new MainUserWithAllIncludesExpression(username);
            return _repository.GetBy<MainUser>(expression);
        }

        public Title GetNextTitle(string titleName)
        {
            
            var titles = _repository.List<Title>().OrderBy(x => x.RequiredAP).ToList();
            var currentTilteIndex = titles.FindIndex(x => x.Name == titleName);
            if (currentTilteIndex == titles.Count - 1)
                return titles.Last();
            var nextTitle = titles[currentTilteIndex + 1];

            return nextTitle;
 
        }

        public Title GetTitleForAchievementPoints(int achievementPoints)
        {
            var title = _repository.List<Title>().Where(x=>x.RequiredAP <= achievementPoints)
                .OrderByDescending(x=>x.RequiredAP).First();

            return title;
            
        }

        public void UpdateAvatar(string username,string path = "Default")
        {
            var user = this.GetMainUserByUsername(username);

            user.AvatarPath = path;

            _repository.Update<MainUser>(user);

        }
    }
}
