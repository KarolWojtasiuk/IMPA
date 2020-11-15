using System;

namespace IMPA
{
    public struct LocationRecord
    {
        public double Latitude;
        public double Longitude;
        public double Accuracy;
        public DateTime Time;

        public LocationRecord(double latitude, double longitude, double accuracy)
        {
            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
            Time = DateTime.UtcNow;
        }
    }
}
