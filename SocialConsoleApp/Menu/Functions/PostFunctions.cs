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
    public class PostFunctions
    {
        private readonly IPost _postManager;
        private readonly IAppUser _user;
        public PostFunctions(IPost postManager,IAppUser user)
        {
            this._postManager = postManager;
            this._user = user;
        }

        public void PrintAllPosts()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("  |Title \t|");
            int i = 1;
            foreach (var post in this._postManager.GetAllPosts())
            {
                Console.WriteLine("{0}|{1} \t|", i,post.Title);
                i++;
            }

        }
        public PostDTO GetPost()
        {
            this.PrintAllPosts();
            Console.WriteLine("Select post(0 to back):");
            try
            {

                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 0)
                {
                    return null;
                }
                return this._postManager.GetAllPosts()[choice - 1];
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public void AddPost()
        {
            Console.WriteLine("Title: ");
            string title =Console.ReadLine();
            Console.WriteLine("Body: ");
            string body = Console.ReadLine();
            this._postManager.CreatePost(this._user.Id, title, body);
        }
    }
}
