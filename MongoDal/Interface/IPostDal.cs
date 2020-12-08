using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDTO;

namespace MongoDal.Interface
{
    public interface IPostDal
    {
        PostDTO CreatePost(PostDTO post);
        PostDTO GetPostById(int id);
        List<PostDTO> GetAllPosts();

        PostDTO UpdatePost(PostDTO post);
        
        void DeletePost(int id);



        void Like(int post_id, LikeDTO like);
        void UnLike(int post_id, LikeDTO like);

        void Dislike(int post_id, DislikeDTO dislike);
        void UnDislike(int post_id, DislikeDTO dislike);


        void AddComment(int id, CommentDTO comment);
        void DeleteComment(int post_id, int comment_id);
    }
}
