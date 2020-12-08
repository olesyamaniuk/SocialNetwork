using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDTO;

namespace MongoDal.Interface
{
    public interface IUserDal
    {
        UserDTO CreateUser(UserDTO user);
        UserDTO GetUserById(int id);
        List<UserDTO> GetAllUsers();
        UserDTO GetUserByLogin(string login);
        UserDTO UpdateUser(UserDTO user);
        void DeleteUser(int id);
        bool Login(string Login, string Password);
    }
}
