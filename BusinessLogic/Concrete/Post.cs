using BusinessLogic.Interface;
using MongoDal.Interface;
using MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class Post : IPost
    {
        private readonly IPostDal _postDal;
        public Post(IPostDal postDal)
        {
            this._postDal = postDal;
        }
        public void AddComment(int PostId, int AuthorId, string CommentText)
        {
            this._postDal.AddCommentToPost(PostId, new CommentDTO { AuthorId = AuthorId, CommentText = CommentText });
        }

        public void AddDislike(int PostId, int UserId)
        {
            var post = this._postDal.GetPostById(PostId);
            if (post.Likes.Where(p => p.UserId == UserId).Count() != 0)
            {
                this._postDal.UnLike(PostId, new LikeDTO{ UserId = UserId });
            }
            if (post.Dislikes.Where(p => p.UserId == UserId).Count() == 0)
            {
                this._postDal.Dislike(PostId, new DislikeDTO() { UserId = UserId });
            }
        }

        public void AddLike(int PostId, int UserId)
        {
            var post = this._postDal.GetPostById(PostId);
            if(post.Dislikes.Where(p => p.UserId == UserId).Count() != 0)
            {
                this._postDal.UnDislike(PostId, new DislikeDTO { UserId = UserId });
            }
            if(post.Likes.Where(p => p.UserId == UserId).Count() == 0)
            {
                this._postDal.Like(PostId, new LikeDTO() {UserId=UserId });
            }
        }

        public void CreatePost(int AuthorId, string Title, string Body)
        {
            this._postDal.CreatePost(new PostDTO { AuthorId = AuthorId, Title = Title, Body = Body, Comments = new List<CommentDTO>(), Dislikes = new List<DislikeDTO>(), Likes = new List<LikeDTO>() });
        }

        public List<PostDTO> GetAllPosts()
        {
            return this._postDal.GetAllPosts();
        }

        public PostDTO GetPostById(int post_id)
        {
            return this._postDal.GetPostById(post_id);
        }
    }
}
