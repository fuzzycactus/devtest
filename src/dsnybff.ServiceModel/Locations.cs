using System.Collections.Generic;
using ServiceStack;

namespace dsnybff.ServiceModel
{
    [Route("/locations")]
    public class GetLocations : IReturn<LocationResponse>
    {
        public string Name { get; set; }
    }

    public class LocationResponse
    {
        public IEnumerable<Location> Locations { get; set; }
    }

    public class Location
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
