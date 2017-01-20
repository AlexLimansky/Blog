using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyBlog.Data.DataContext;
using MyBlog.Data.Entities;

namespace MyBlog.Web.Controllers
{
    public class PostsController : ApiController
    {
        private DataContext db = new DataContext();
        public IEnumerable<Post> Get(string username)
        {
            var posts = db.Blogs.First(a => a.Username == username).Posts.OrderByDescending(a => a.Created);
            return posts.ToList();
        }
    }
}
