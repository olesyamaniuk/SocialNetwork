using BusinessLogic.Interface;
using MongoDTO;
using SocialConsoleApp.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConsoleApp.Menu.Functions
{
    public class UserPageFunctions
    {
        private readonly IAppUser _user;
        private readonly IUser _userManager;
        private UserDTO _chosenUser;
        public UserPageFunctions(IAppUser user, IUser userManager, UserDTO chosenUser)
        {
            this._userManager = userManager;
            this._user = user;
            this._chosenUser = chosenUser;
        }

        public void PrintUserInfo()
        {
            Console.WriteLine("User name: {0}",_chosenUser.UserName);
            Console.WriteLine("User last name: {0}", _chosenUser.UserLastName);
            Console.WriteLine("Interests:");
            foreach (var interes in _chosenUser.Interests)
            {
                Console.WriteLine("{0},", interes);
            }
            Console.WriteLine("");
            var is_follow = this._userManager.IsFollowed(this._user.Id, this._chosenUser.UserId);
            if (is_follow)
            {
                Console.WriteLine("You follow this user.");
            }
            else
            {
                var path = this._userManager.MinPathBetween(this._user.Id, this._chosenUser.UserId);
                if (path > 0)
                {
                    Console.WriteLine("Minimum path to this user: {0}",path);
                }
            }
        }

        public void FollowThisUser()
        {
            this._userManager.Follow(this._user.Id, this._chosenUser.UserId);
        }
        public void UnfollowThisUser()
        {
            this._userManager.UnFollow(this._user.Id, this._chosenUser.UserId);
        }
    }
}
