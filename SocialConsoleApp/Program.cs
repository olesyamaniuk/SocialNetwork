using BusinessLogic.Concrete;
using BusinessLogic.Interface;
using MongoDal.Concrete;
using MongoDal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using SocialConsoleApp.AppUser;
using SocialConsoleApp.Menu;
using Neo4jDal.Concrete;
using Neo4jDal.Interface;

namespace SocialConsoleApp
{
    class ProgramApp
    {
        public static UnityContainer Container;
        public static string _connString;
        public static string _DbName;

        public static string _connNeo4j, _login, _pass;
        static void Main()
        {
            _connString = "mongodb://localhost:27017/";
            _DbName = "SocialNetwork";
            _connNeo4j = "http://localhost:7474/db/data/";
            _login = "neo4j";
            _pass = "00000";
            ConfigureContainer();


            AppMenu.ShowEntry();

        }

        private static void ConfigureContainer()
        {
            Container = new UnityContainer();
            Container.RegisterInstance<IAppUser>(new SocialConsoleApp.AppUser.AppUser());
            Container.RegisterType<IManager, Manager>()
                .RegisterType<IPost, Post>()
                .RegisterType<IUser, User>();
            Container
                .RegisterType<IUserDal, UserDal>(new InjectionConstructor(_connString,_DbName))
                .RegisterType<IPostDal, PostDal>(new InjectionConstructor(_connString, _DbName));
            Container
              .RegisterType<IFollowersDal, FollowersDal>(new InjectionConstructor(_connNeo4j, _login, _pass));
        }
    }
}
