using System;

namespace MyBlog.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
    }
}