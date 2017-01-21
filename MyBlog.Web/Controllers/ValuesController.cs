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
using MyBlog.Data.Entities;
using MyBlog.Logic;

namespace MyBlog.Web.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        private IdentityDbContext UsersContext = new IdentityDbContext();
        // GET api/values
        public IEnumerable<string> GetUserList()
        {
            var users = UsersContext.Users.OrderBy(a=>a.UserName).ToListAsync().Result;
            return users.Select(user => user.UserName).ToList();
        }

        // GET api/values/5
        public IEnumerable<Post> Get(string username)
        {
            var posts = _uow.Posts.All().Where(a => a.Username == username).OrderByDescending(a=>a.Created).ToList();
            return posts;
        }

        // POST api/values
        [HttpPost]
        public void CreatePost([FromBody]Post item)
        {
            var username = HttpContext.Current.User.Identity.Name;
            item.Created = DateTime.Now;
            item.Username = username;
            _uow.Posts.Create(item);
            _uow.Save();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _uow.Posts.Delete(id);
            _uow.Save();
        }

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }

    }
}
