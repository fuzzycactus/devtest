using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Templates;
using ServiceStack.DataAnnotations;
using ServiceStack.Text;

using dsnybff.ServiceModel;
using dsnybff.ServiceModel.Types;

namespace dsnybff.ServiceInterface
{
    public class PostsService : Service
    {
        public IEnumerable<Post> Any(GetPosts request)
        {
            var locations = TryResolve<List<Post>>();

            var items = request.Topic.IsNullOrEmpty() ? locations :
                locations.Where(a => a.Topics.Contains(request.Topic.ToLower()));

            return items;
        }
    }
}
