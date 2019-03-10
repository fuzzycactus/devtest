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
            var itemList = TryResolve<List<Post>>();

            var items = request.Topic.IsNullOrEmpty() ? itemList : itemList.Where(a => a.Topics.Contains(request.Topic.ToLower()));

            return items;
        }

        public IEnumerable<Post> Any(ReloadPosts request)
        {
            HostContext.AppHost.ReloadCsv<Post>();
            return Any(new GetPosts());
        }
    }
}
