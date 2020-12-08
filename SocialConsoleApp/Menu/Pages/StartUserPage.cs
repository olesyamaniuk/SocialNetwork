using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConsoleApp.Menu.Pages
{
    public class StartUserPage : IPage
    {
        public StartUserPage()
        {

        }
        public  void Display()
        {
            while (true)
            {
                int choice = 0;
                Console.WriteLine("Main");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1.Users");
                Console.WriteLine("2.Posts");
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
                        new UserStartPage().Display();
                        break;
                    case 2:
                        new PostStartPage().Display();
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
