using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConsoleApp.AppUser
{
    public interface IAppUser
    {
        int Id { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        bool IsLogined { get; set; }
    }
}
