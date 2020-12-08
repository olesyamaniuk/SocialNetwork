using BusinessLogic.Interface;
using MongoDal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class Manager : IManager
    {
        private readonly IUserDal _mongoDal;
        public Manager(IUserDal mongoDal)
        {
            this._mongoDal = mongoDal;
        }

        public bool Login(string Login, string Password)
        {
            try
            {
                return this._mongoDal.Login(Login, Password);
            }
            catch(Exception exp)
            {
                return false;
            }
        }
    }
}
