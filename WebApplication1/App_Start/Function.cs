using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication1.App_Start
{
    public class Function
    {
        protected string projectID;
        protected string userID;
        protected string appID;
        protected string ipAddress;
        protected string format = "xml";
        protected MD.Enum.ApplicationLogStatus requestStatus = MD.Enum.ApplicationLogStatus.Fail;//确认应用请求为失败
        protected bool EGroup = false;
        protected string userToken;
        protected MD.Entity.Project currentProject = null;
        protected MD.Entity.User currentUser = null;

        public Dictionary<string,object> getTokenObj(string access_token)
        {
            Dictionary<string, object> tokenDic = new Dictionary<string, object>();
            string accessUserInfo = MD.Business.OAuthToken.GetOAuthAccessToken(access_token);
            if (!string.IsNullOrEmpty(accessUserInfo))
            {
                projectID = accessUserInfo.Split('|')[1];
                userID = accessUserInfo.Split('|')[2];
                currentProject = MD.Business.Project.GetProjectDetail(projectID);
                currentUser = currentProject.FindUser(userID);
            }
            return tokenDic;
        }

    }
}