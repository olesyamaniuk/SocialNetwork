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
    class PostPageFunctions
    {
        private readonly IPost _postManager;
        private IAppUser _user;
        private PostDTO _post;
        private IUser _userManager;
         public PostPageFunctions(IPost postManager,IAppUser user,PostDTO post,IUser userManager)
         {
             this._postManager = postManager;
             this._user = user;
             this._post = post;
            this._userManager = userManager;
         }
        public void PrintCurrentPost()
        {
            var post_author = this._userManager.GetUserById(this._post.AuthorId);
            Console.WriteLine("Author: {0} {1}",post_author.UserName,post_author.UserLastName);
            Console.WriteLine("Title: ");
            Console.WriteLine(this._post.Title);
            Console.WriteLine("Body: ");
            Console.WriteLine(this._post.Body);

            Console.WriteLine("Likes: {0}", this._post.Likes.Count());
            Console.WriteLine("Disikes: {0}", this._post.Dislikes.Count());

        }
        public void PrintComments()
        {
            Console.WriteLine("Comments: ");
            foreach(var comment in this._post.Comments)
            {
                var comment_author = this._userManager.GetUserById(comment.AuthorId);
                Console.WriteLine("Author: {0} {1}", comment_author.UserName, comment_author.UserLastName);
                Console.WriteLine("Comment text: ");
                Console.WriteLine(comment.CommentText);
            }
        }

        public void AddComment()
        {
            Console.WriteLine("Write comment text:");
            var comment = Console.ReadLine();
            this._postManager.AddCommentToPost(this._post.PostId, this._user.Id, comment);
        }



    }
}
