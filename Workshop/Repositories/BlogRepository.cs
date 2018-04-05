using System.Collections.Generic;
using Workshop.Entities;

namespace Workshop.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private static readonly List<Blog> Blogs = new List<Blog>();
        private static int _id;

        public IEnumerable<Blog> Read()
        {
            return Blogs;
        }

        public Blog Create(Blog blog)
        {
            if (blog.Id <= 0)
            {
                blog.Id = ++_id;
                Blogs.Add(blog);
            }

            return blog;
        }

        public void Delete(int id)
        {
            Blogs.RemoveAll(blog => blog.Id == id);
        }

    }
}
