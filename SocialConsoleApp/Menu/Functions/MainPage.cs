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
    public class MainPage
    {
        private IAppUser _user;
        private readonly IManager _authManager;
        private readonly IUser _userManager;
        public MainPage(IAppUser user, IManager authManager, IUser userManager)
        {
            this._user = user;
            this._authManager = authManager;
            this._userManager = userManager;
        }
        public bool Login()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (this._authManager.Login(login, password))
            {
                this._user.Login = login;
                this._user.Id = this._userManager.GetUserByLogin(login).UserId;
                this._user.IsLogined = true;
                return true;
            }
            else
            {
                this._user.IsLogined = false;
                return false;
            }
        }
        public void Register()
        {
            var user = new UserDTO();
            Console.Write("Login: ");
            user.UserLogin= Console.ReadLine();
            Console.Write("Password: ");
            user.UserPassword = Console.ReadLine();

            Console.Write("Name: ");
            user.UserName = Console.ReadLine();
            Console.Write("Last Name: ");
            user.UserLastName= Console.ReadLine();

            Console.Write("Email: ");
            user.Email = Console.ReadLine();
            Console.Write("Interests: ");
            user.Interests = Console.ReadLine().Split(',').ToList();

            this._userManager.CreateUser(user);

        }
    }
}
