using System.Collections.Generic;
using ServiceStack;

namespace dsnybff.ServiceModel
{
    [Route("/posts")]
    public class GetPosts : IReturn<IEnumerable<Post>>
    {
        public string Topic { get; set; }
    }

    [Route("/posts/reload")]
    public class ReloadPosts : IReturn<IEnumerable<Post>>
    { }

    public class PostResponse
    {
        public IEnumerable<Post> Items { get; set; }
    }
}
