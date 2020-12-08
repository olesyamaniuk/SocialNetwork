using BusinessLogic.Interface;
using SocialConsoleApp.AppUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConsoleApp.AppUser
{
    public class AppUser:IAppUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set;}
        public bool IsLogined { get; set; }
    }
}
