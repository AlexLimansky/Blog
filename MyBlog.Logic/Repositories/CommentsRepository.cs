using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyBlog.Data.DataContext;
using MyBlog.Data.Entities;

namespace MyBlog.Logic.Repositories
{
    public class CommentsRepository :IRepository<Comment>
    {
        private DataContext _db;

        public CommentsRepository(DataContext context)
        {
            _db = context;
        }

        public IEnumerable<Comment> All()
        {
            return _db.Comments;
        }

        public Comment GetItem(int id)
        {
            return _db.Comments.FindAsync(id).Result;
        }

        public void Create(Comment item)
        {
            _db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            var c = _db.Comments.FindAsync(id).Result;
            if (c != null)
            {
                _db.Comments.Remove(c);
            }
        }

        public void Update(Comment item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}