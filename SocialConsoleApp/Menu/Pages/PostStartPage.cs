using SocialConsoleApp.Menu.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SocialConsoleApp.Menu.Pages
{
    public class PostStartPage : IPage
    {
        public void Display()
        {
            Console.Clear();
            while (true)
            {
                int choice = 0;
                var Func = ProgramApp.Container.Resolve<PostFunctions>();
                Console.WriteLine("Post Start Page");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1.View All Posts");
                Console.WriteLine("2.View post by id");
                Console.WriteLine("3.Add new post");
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
                        Func.PrintAllPosts();
                        break;
                    case 2:
                        var post = Func.GetPost();
                        if (post != null)
                        {
                            new PostPage(post).Display();
                        }
                        break;
                    case 3:
                        Func.AddPost();
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
