using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using MD.Entity;
using MD.Business;
using MD.Threading;
using MD.Enum;
using System.Diagnostics;
using ServiceStack.Text;

namespace ServiceStack
{
    //Request DTO
    public class User
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
        public string Field { get; set; }
    }

    //Response DTO
    public class UserResponse
    {
        public string Result { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> DicResult { get; set; }

        //public ResponseStatus ResponseStatus { get; set; } //Where Exceptions get auto-serialized
    }

    public class UserService : Service
    {
        public object Get(User request)
        {
            string userName = request.Name;
            string address = request.Address;
            string age = request.Age;
            string Id = request.Id;
            string field = request.Field;

            if (!string.IsNullOrEmpty(Id))
            {
                if (!string.IsNullOrEmpty(field))
                    return new UserResponse { Result = "Id=" + Id + "; Field=" + field, Action = "get" };
                else
                    return new UserResponse { Result = "Id=" + Id, Action = "get" };
            }
            else
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("userName", userName);
                dic.Add("userAge", age);
                dic.Add("userAddress", address);

                return new UserResponse { DicResult = dic, Action = "get" };
            }

        }

        public object Post(User request)
        {
            string userName = request.Name;
            string address = request.Address;
            string age = request.Age;
            string Id = request.Id;
            string field = request.Field;

            if (!string.IsNullOrEmpty(Id))
            {
                if (!string.IsNullOrEmpty(field))
                    return new UserResponse { Result = "Id=" + Id + "; Field=" + field, Action = "post" };
                else
                    return new UserResponse { Result = "Id=" + Id, Action = "post" };
            }
            else
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("userName", userName);
                dic.Add("userAge", age);
                dic.Add("userAddress", address);

                return new UserResponse { DicResult = dic, Action = "post" };
            }
        }


        public object Delete(User request)
        {
            string userName = request.Name;
            string address = request.Address;
            string age = request.Age;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("userName", userName);
            dic.Add("userAge", age);
            dic.Add("userAddress", address);

            return new UserResponse { DicResult = dic };
        }

        public object Any(User request)
        {
            string userName = request.Name;
            string address = request.Address;
            string age = request.Age;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("userName", userName);
            dic.Add("userAge", age);
            dic.Add("userAddress", address);

            return new UserResponse { DicResult = dic };

        }
    }

}