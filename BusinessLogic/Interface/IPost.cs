using MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IPost
    {
        List<PostDTO> GetAllPosts();
        PostDTO GetPostById(int post_id);
        void CreatePost(int Author_Id, string Title, string Body);
        void AddComment(int PostId, int AuthorId, string CommentText);
        void AddLike(int PostId, int UserId);
        void AddDislike(int PostId, int UserId);
    }
}
