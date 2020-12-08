using MongoDTO;
using SocialConsoleApp.Menu.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace SocialConsoleApp.Menu.Pages
{
    public class UserPage : IPage
    {
        private UserDTO _user;
        public UserPage(UserDTO user)
        {
            this._user = user;
        }
        public void Display()
        {
            Console.Clear();
            while (true)
            {
                int choice = 0;
                var Func = ProgramApp.Container.Resolve<UserPageFunctions>(new ParameterOverride("chosenUser", this._user));

                Func.PrintUserInfo();
                Console.WriteLine("1.Follow");
                Console.WriteLine("2.Unfollow");
                Console.WriteLine("0.Back");
                Console.WriteLine("Choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid page number.");
                }
                switch (choice)
                {
                    case 1:
                        Func.FollowThisUser();
                        return;
                        break;
                    case 2:
                        Func.UnfollowThisUser();
                        return;
                        break;
                    case 0:
                        return;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
