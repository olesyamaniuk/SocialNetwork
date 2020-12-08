using Neo4jDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4jDal.Interface
{
    public interface IFollowersDal
    {
        void AddUser(UserLableDTO u);
        void DeleteUser(UserLableDTO u);
        UserLableDTO GetUserById(int id);
        void DeleteAllRelationships(UserLableDTO u1, UserLableDTO u2);
        void AddFollower(UserLableDTO from, UserLableDTO to);
        void AddFollower(int from, int to);
        bool HaveAnyRelationship(UserLableDTO u1, UserLableDTO u2);
        bool HaveRelationship(int from, int to);
        int MinPathBetween(UserLableDTO u1, UserLableDTO u2);
        int MinPathBetween(int id1, int id2);
    }
}
