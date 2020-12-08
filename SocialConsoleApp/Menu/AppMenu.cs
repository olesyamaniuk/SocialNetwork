using SocialConsoleApp.Menu.Functions;
using SocialConsoleApp.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SocialConsoleApp.Menu
{
    public static class AppMenu
    {
        private static void Show()
        {
            var page = new StartUserPage();
            page.Display();
        }
        public static void ShowEntry()
        {
            while (true)
            {
                int choice =0;
                Console.WriteLine("Main");
                Console.WriteLine("-----------------------------");
                Console.Clear();
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Register");
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
                var page = ProgramApp.Container.Resolve<MainPage>();
                switch (choice)
                {
                    case 1:
                        if (page.Login())
                        {
                            Show();
                        }
                        else
                        {
                            Console.WriteLine("Logined failed.");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        page.Register();
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
