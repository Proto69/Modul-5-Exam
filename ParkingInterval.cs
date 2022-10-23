using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Изпит_Модул_5
{
    public class ParkingInterval
    {
        private ParkingSpot parkingSpot;

        public ParkingSpot ParkingSpot
        {
            get
            {
                return parkingSpot;
            }

            set
            {
                parkingSpot = value;
            }
        }

        private string registrationPlate;

        public string RegistrationPlate
        {
            get
            {
                return registrationPlate;
            }

            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Registration plate can’t be null or empty!");
                registrationPlate = value;
            }
        }

        private int hoursParked;

        public int HoursParked
        {
            get
            {
                return hoursParked;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("Hours parked can’t be zero or negative!");
                hoursParked = value;
            }
        }

        public double Revenue
        {
            get
            {
                if (parkingSpot.Type == "subscription")
                    return 0;
                double sum = hoursParked * parkingSpot.Price;
                return sum;
            }
        }

        public ParkingInterval(ParkingSpot parkingSpot, string registrationPlate, int hoursParked)
        {
            ParkingSpot = parkingSpot;
            RegistrationPlate = registrationPlate;
            HoursParked = hoursParked;
        }

        public override string ToString()
        {
            string result = $"\n> Parking Spot #{parkingSpot.Id}\n> RegistrationPlate: {RegistrationPlate}\n> HoursParked: {hoursParked}\n> Revenue: {Revenue:F2} BGN";
            return result;
        }
    }
}
