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
    public class LocationService : Service
    {
        public IEnumerable<Location> Any(GetLocations request)
        {
            var itemList = TryResolve<List<Location>>();

            var items = request.Topic.IsNullOrEmpty() ? itemList :
                itemList.Where(a => a.Topics.ToList().Contains(request.Topic.ToLower()));

            return items;
        }

        public IEnumerable<Location> Any(ReloadLocations request)
        {
            HostContext.AppHost.ReloadCsv<Location>();
            return Any(new GetLocations());
        }
    }
}
