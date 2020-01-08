
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corridor.Models
{
    public class GeoCalc
    {
        public static double DistanceBetween(double lat1,double long1,double lat2,double long2)
        {
           return new Coordinates(lat1, long1)
                .DistanceTo(
                    new Coordinates(lat2, long2),
                    UnitOfLength.Kilometers
                );
        }
        public static List<(double, double)> Ambulances;

        static public bool IsMyDeviceInRange(double lat1, double long1,double range)
        {
            if (Ambulances == null)
                Ambulances = new List<(double, double)>()
                {
                    (0.5,0.5)
                };
            foreach(var location in Ambulances)
            {
                if (DistanceBetween(location.Item1,location.Item2,lat1,long1)<range)
                {
                    return true;
                }
               
            }
            return false;
        }
    }
}
