using System.Collections.Generic;
using System.Data.Entity;
using MyBlog.Data.DataContext;
using MyBlog.Data.Entities;

namespace MyBlog.Logic.Repositories
{
    public class PostsRepository : IRepository<Post>
    {
        private DataContext _db;

        public PostsRepository(DataContext context)
        {
            _db = context;
        }
        public IEnumerable<Post> All()
        {
            return _db.Posts;
        }

        public Post GetItem(int id)
        {
            return _db.Posts.FindAsync(id).Result;
        }

        public void Create(Post item)
        {
            _db.Posts.Add(item);
        }

        public void Delete(int id)
        {
            var p = _db.Posts.FindAsync(id).Result;
            if (p != null)
            {
                _db.Posts.Remove(p);
            }
        }

        public void Update(Post item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}