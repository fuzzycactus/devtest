using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Templates;
using ServiceStack.DataAnnotations;
using dsnybff.ServiceModel;

namespace dsnybff.ServiceInterface
{
    public class LocationService : Service
    {
        public object Any(GetLocations request)
        {
            return new LocationResponse {
                 Locations = new List<Location> {
                    new Location {  Code = "mk", Name = "Magic Kingdom"},
                    new Location {  Code = "ak", Name = "Animal Kingdom"}
                }
            };
        }
    }
}
