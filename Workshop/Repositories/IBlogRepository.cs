using System.Collections.Generic;
using Workshop.Entities;

namespace Workshop.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> Read();

        Blog Read(int id);

        Blog Create(Blog blog);
    }
}
