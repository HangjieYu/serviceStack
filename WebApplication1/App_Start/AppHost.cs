using System.Configuration;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;


using MDPost;namespace ServiceStack.App_Start
{
    public class AppHost : AppHostBase
    {
        public AppHost() //Tell ServiceStack the name and where to find your web services
            : base("ServiceStack", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Funq.Container container)
        {
            //Configure User Defined REST Paths
            Routes
              .Add<User>("/user")
              .Add<User>("/user/{Id}/{Field*}");

            Routes
             .Add<PostAll>("/post/all");

            //Routes
            //  .Add<Todo>("/todos", "POST");

        }
    }

}
