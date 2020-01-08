using Corridor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostconeDataManager.Models
{
    static public class LocationProvider
    {
        static Dictionary<string, LocationMeasurement> Users = new Dictionary<string, LocationMeasurement>();

        public static void AddLocation(string UserID, (double latitude, double longtitude) location)
        {
            if (UserID == null)
                UserID = "Unregistered";
            var locationToStore = new LocationMeasurement() { Lattitude = location.latitude, Longtitude = location.longtitude };
            if (Users.ContainsKey(UserID))
                Users[UserID] = locationToStore;
            else
                Users.Add(UserID, locationToStore);
        }
        public static Dictionary<string, LocationMeasurement> GetUsersWithinRange(double range, (double lattitude,double longtitude) searcher)
        {
            var UsersWithinRange = new Dictionary<string, LocationMeasurement>();
            foreach (var user in Users)
            {
                if (GeoCalc.DistanceBetween(searcher.lattitude,searcher.longtitude,user.Value.Lattitude,user.Value.Longtitude)<range)
                {
                    UsersWithinRange.Add(user.Key,user.Value);
                }
            }
            return UsersWithinRange;   
        }
    }
}