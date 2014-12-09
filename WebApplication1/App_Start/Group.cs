using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using MD.Business;

namespace MDGroup
{
    public class Group
    {
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public string Members { get; set; }
    }

    //Response DTO
    public class GroupResponse
    {
        public string Result { get; set; }
        public Dictionary<string, string> DicResult { get; set; }
    }

    //Can be called via any endpoint or format, see: http://mono.servicestack.net/ServiceStack.Hello/
    public class GrouupService : Service
    {
        public object Any(Group request)
        {
            string groupName = request.GroupName;
            string groupID = request.GroupID;
            string members = request.Members;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("groupName", groupName);
            dic.Add("groupID", groupID);
            dic.Add("members", members);

            return new GroupResponse { DicResult = dic };

        }
    }
}