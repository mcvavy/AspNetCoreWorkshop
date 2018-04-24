using System.Collections;
using System.Collections.Generic;

namespace Workshop.Settings
{
    public class BlogSettings
    {
        public string Title { get; set; }

        public BlogType BlogType { get; set; }

        public IDictionary<string, string> Properties { get; set; }
    }

    public enum BlogType
    {
        Games,
        Education
    }
}
