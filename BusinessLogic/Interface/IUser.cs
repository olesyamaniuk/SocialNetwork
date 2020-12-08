using MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IUser
    {

        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
        UserDTO GetUserByLogin(string login);
        bool CreateUser(UserDTO user);

        void Follow(int from, int to);
        void UnFollow(int from, int to);
        bool IsFollowed(int from, int to);
        int MinPathBetween(int from, int to);
    }
}
