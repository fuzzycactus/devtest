using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Templates;
using ServiceStack.DataAnnotations;
using ServiceStack.Text;

using dsnybff.ServiceModel;

namespace dsnybff.ServiceInterface
{
    public class LocationService : Service
    {
        public IEnumerable<Location> Any(GetLocations request)
        {
            var locations = TryResolve<List<Location>>();

            var items = request.Topic.IsNullOrEmpty() ? locations :
                locations.Where(a => a.Topics.Contains(request.Topic.ToLower()));

            return items;
        }
    }
}
