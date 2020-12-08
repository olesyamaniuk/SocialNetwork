using SocialConsoleApp.Menu.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SocialConsoleApp.Menu.Pages
{
    public class UserStartPage : IPage
    {
        public void Display()
        {
            while (true)
            {
                int choice = 0;
                Console.Clear();
                Console.WriteLine("Users Page");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1.Display all users");
                Console.WriteLine("2.Go to user page");
                Console.WriteLine("0.Exit");
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
                        ProgramApp.Container.Resolve<UsersFunctions>().DisplayAllUsers();
                        break;
                    case 2:
                        var user = ProgramApp.Container.Resolve<UsersFunctions>().GetUser();
                        if(user != null)
                        {
                            new UserPage(user).Display();
                        }
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
