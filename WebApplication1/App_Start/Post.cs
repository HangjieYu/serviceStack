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
using ServiceStack.App_Start;

using WebApplication1;

namespace MDPost
{
    //Request DTO
    public class PostAll : Global
    {
        public string a = string.Empty;

        public PostAll() {
            a = access_token;
        }
    }

    [Route("/post/detail", "Post")]
    public class PostDetail
    {
        public string pID { get; set; }
    }

    //Respon DTO
    public class PostResponse
    {
        public string Result { get; set; }
        public Dictionary<string, string> DicResult { get; set; }
        public MD.Entity.PostList postList { get; set; }
        public MD.Entity.Post postItem { get; set; }

        public ResponseStatus ResponseStatus { get; set; } //Where Exceptions get auto-serialized
    }

    public class PostService : Service
    {
        MD.Entity.PostList postList = new MD.Entity.PostList();
        MD.Entity.Post postItem = new MD.Entity.Post();
        Stopwatch watch = new Stopwatch();

        string userID = "bb4c7fd9-5a9e-419d-946b-efe70530b974";
        string projectID = "fe288386-3d26-4eab-b5d2-51eeab82a7f9";

        public object Get(PostAll request)
        {
            int sincePostID = 0;
            int maxPostID = 0;
            int pageSize = 20;

            string accessToken = request.access_token;

            watch.Start();

            //赋值方法参数
            MD.Business.Parameter.PostPara pPara = new MD.Business.Parameter.PostPara();
            pPara.PostType = MD.Enum.PostType.All;

            postList = MD.Business.Post.GetProjectPosts(pPara, userID, projectID, sincePostID == 0 ? string.Empty : sincePostID.ToString(), maxPostID == 0 ? string.Empty : maxPostID.ToString(), pageSize);

            watch.Stop();
            return new PostResponse { postList = postList, Result = "时间间隔为:{0}秒" + watch.ElapsedMilliseconds / 1000.0f };
            //return new PostResponse { timeStamp = timeStamp, postList = postList };


        }

        public object Get(PostDetail request)
        {
            watch.Start();

            string pID = request.pID;
            if (!string.IsNullOrEmpty(pID))
            {
                postItem = MD.Business.Post.GetPostDetail(pID, userID, projectID);
            }

             watch.Stop();
             return new PostResponse { postItem = postItem, Result = "时间间隔为:{0}秒" + watch.ElapsedMilliseconds / 1000.0f};
        }

        public object Post(PostDetail request)
        {
            watch.Start();

            string pID = request.pID;
            if (!string.IsNullOrEmpty(pID))
            {
                postItem = MD.Business.Post.GetPostDetail(pID, userID, projectID);
            }

            watch.Stop();
            return new PostResponse { postItem = postItem, Result = "时间间隔为:{0}秒" + watch.ElapsedMilliseconds / 1000.0f };
        }

    }
}