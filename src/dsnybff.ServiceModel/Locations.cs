using System.Collections.Generic;
using ServiceStack;

namespace dsnybff.ServiceModel
{
    [Route("/locations")]
    [Route("/{Topic}/locations")]
    public class GetLocations : IReturn<IEnumerable<Location>>
    {
        public string Topic { get; set; }
    }

    public class LocationResponse
    {
        public IEnumerable<Location> Locations { get; set; }
    }

    public class Location
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abv { get; set; }
        public IEnumerable<string> Topics { get; set; }
        public int IconImageId { get; set; }
    }
}
