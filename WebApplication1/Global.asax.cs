using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack.App_Start;
using ServiceStack;

using ServiceStack.MiniProfiler;
using ServiceStack.Messaging;
using Newtonsoft.Json;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {
        public string access_token{ get; set; }

        public void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }

        public void Application_BeginRequest(object src, EventArgs e)
        {
            if (Request["accesstoken"] != null)
            {
                access_token = Request["accesstoken"].ToString();
                //string accessUserInfo = MD.Business.OAuthToken.GetOAuthAccessToken(access_token);
                //if (!string.IsNullOrEmpty(accessUserInfo))
                //{
                //    projectID = accessUserInfo.Split('|')[1];
                //    userID = accessUserInfo.Split('|')[2];
                //    currentProject = MD.Business.Project.GetProjectDetail(projectID);
                //    currentUser = currentProject.FindUser(userID);
                //}
                Application.Add("access_token", access_token);
            }
        }

        protected void Application_EndRequest(object src, EventArgs e)
        {
            Application.Clear();
        }

    }
}