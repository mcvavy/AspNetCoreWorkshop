using System.Collections.Generic;
using System.Linq;
using Workshop.Entities;

namespace Workshop.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private static readonly List<Blog> Blogs = new List<Blog>
        {
            new Blog {Id = 1, Title = "Welcome", Body = "This is the first entry in our ASP.NET Core blog"},
            new Blog {Id = 2, Title = "What else can I do?", Body = "ASP.NET Core Workshop for META 2018"}
        };

        private static int _id = Blogs.Max(blog => blog.Id);

        public IEnumerable<Blog> Read()
        {
            return Blogs;
        }

        public Blog Read(int id)
        {
            return Blogs.Single(blog => blog.Id == id);
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
    }
}
