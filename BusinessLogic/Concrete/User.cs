using BusinessLogic.Interface;
using MongoDal.Interface;
using MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jDal;
using Neo4jDTO;
using Neo4jDal.Interface;

namespace BusinessLogic.Concrete
{
    public class User : IUser
    {
        private readonly IUserDal _mongoDal;
        private readonly IFollowersDal _FollowerDal;

        public User(IUserDal mongoDal, IFollowersDal FollowerDal)
        {
            this._FollowerDal = FollowerDal;
            this._mongoDal = mongoDal;
        }

        public bool CreateUser(UserDTO user)
        {
            try
            {
                this._mongoDal.CreateUser(user);
                this._FollowerDal.AddUser(new UserLableDTO { UserId = user.UserId, UserLogin = user.UserLogin });
                return true;
            }
            catch(Exception exp)
            {
                return false;
            }
        }

        public void Follow(int from, int to)
        {
            var u = this._mongoDal.GetUserById(from);
            if(!u.FollowedIdList.Contains(to))
            {
                u.FollowedIdList.Add(to);
                this._FollowerDal.AddFollow(from, to);
                this._mongoDal.UpdateUser(u);
            }
        }


        public List<UserDTO> GetAllUsers()
        {
            return this._mongoDal.GetAllUsers();
        }

        public UserDTO GetUserById(int id)
        {
            return this._mongoDal.GetUserById(id);
        }

        public UserDTO GetUserByLogin(string login)
        {
            return this._mongoDal.GetUserByLogin(login);
        }

        public bool IsFollowed(int from, int to)
        {
            return this._FollowerDal.HasRelationship(from, to);
        }

        public int MinPathBetween(int from, int to)
        {
            return this._FollowerDal.MinPathBetween(from, to);
        }

        public void UnFollow(int from, int to)
        {
            var u = this._mongoDal.GetUserById(from);
            if (u.FollowedIdList.Contains(to))
            {
                u.FollowedIdList.Remove(to);
                this._FollowerDal.DeleteAllRelationships(new UserLableDTO { UserId = from }, new UserLableDTO { UserId = to });
                this._mongoDal.UpdateUser(u);
            }
        }
    }
}
