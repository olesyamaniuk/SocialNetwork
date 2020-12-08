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
    public class UsersFunctions
    {
        private readonly IAppUser _user;
        private readonly IUser _userManager;

        public UsersFunctions(IAppUser user,IUser userManager)
        {
            this._user = user;
            this._userManager = userManager;
        }

        public void DisplayAllUsers()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("  |Name \t| Last Name \t|");
            int i = 1;
            foreach(var u in this._userManager.GetAllUsers().Where(p => p.UserId != this._user.Id).ToList())
            {
                Console.WriteLine("{0}|{1} \t| {2} \t|\n",i,u.UserName,u.UserLastName);
                i++;
            }

        }
        public UserDTO GetUser()
        {
            this.DisplayAllUsers();
            Console.WriteLine("Select user(0 to back):");
            try
            {

                var choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 0)
                {
                    return null;
                }
                return this._userManager.GetAllUsers().Where(p => p.UserId != this._user.Id).ToList()[choice-1];
            }
            catch(Exception exp)
            {
                return null;
            }
            
        }

    }
}
