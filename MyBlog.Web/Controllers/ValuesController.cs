using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyBlog.Data.DataContext;
using MyBlog.Data.Entities;

namespace MyBlog.Web.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private DataContext db = new DataContext();
        private IdentityDbContext UsersContext = new IdentityDbContext();
        // GET api/values
        public IEnumerable<string> GetUserList()
        {
            var users = UsersContext.Users.OrderBy(a=>a.UserName).ToListAsync().Result;
            var result = new List<string>();
            foreach (var user in users)
            {
                result.Add(user.UserName);
            }
            return result;
        }

        // GET api/values/5
        public IEnumerable<Post> Get(string username)
        {
            if (!db.Blogs.Any(a => a.Username == username))
            {
                var b = new Blog { Username = username };
                db.Blogs.Add(b);
                db.SaveChanges();
            }
            var posts = db.Blogs.FirstAsync(a => a.Username == username).Result.Posts.OrderByDescending(a => a.Created);
            return posts.ToList();
        }

        // POST api/values
        [HttpPost]
        public void CreatePost([FromBody]Post item)
        {
            item.Created = DateTime.Now;
            var username = HttpContext.Current.User.Identity.Name;
            if (!db.Blogs.Any(a => a.Username == username))
            {
                var b = new Blog {Username = username};
                db.Blogs.Add(b);
                var blog = db.Blogs.First(a => a.Username == username);
                blog.Posts.Add(item);
                db.SaveChanges();
            }
            var bl = db.Blogs.First(a => a.Username == username);
            bl.Posts.Add(item);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
