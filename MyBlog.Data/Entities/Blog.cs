using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Blog()
        {
            Posts = new List<Post>();
        }
    }
}
