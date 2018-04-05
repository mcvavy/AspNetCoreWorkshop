using System.Collections.Generic;
using Workshop.Entities;

namespace Workshop.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> Read();


        Blog Create(Blog blog);


        void Delete(int id);
    }
}
