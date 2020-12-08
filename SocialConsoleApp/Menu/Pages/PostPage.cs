using MongoDTO;
using SocialConsoleApp.Menu.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace SocialConsoleApp.Menu.Pages
{
    public class PostPage:IPage
    {
        private PostDTO _post;
        public PostPage(PostDTO post)
        {
            this._post = post;
        }

        public void Display()
        {
            Console.Clear();
            while (true)
            {
                int choice = 0;
                var Func = ProgramApp.Container.Resolve<PostPageFunctions>(new ParameterOverride("post", this._post));
                Console.WriteLine("-----------------------------");
                Func.PrintCurrentPost();
                Console.WriteLine("1.View All Comments");
                Console.WriteLine("2.Add Comment");
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
                        Func.PrintComments();
                        break;
                    case 2:
                        Func.AddComment();
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
