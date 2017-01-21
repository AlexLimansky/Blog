using System;
using MyBlog.Data.DataContext;
using MyBlog.Logic.Repositories;

namespace MyBlog.Logic
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _db = new DataContext();
        private PostsRepository postRepository;
        private CommentsRepository commentRepository;

        public PostsRepository Posts
        {
            get { return postRepository ?? (postRepository = new PostsRepository(_db)); }
        }

        public CommentsRepository Commens
        {
            get { return commentRepository ?? (commentRepository = new CommentsRepository(_db)); }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}