using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Изпит_Модул_5
{
    internal class ParkingController
    {
        private List<ParkingSpot> parkingSpots;

        public ParkingController()
        {
            parkingSpots = new List<ParkingSpot>();
        }

        public string CreateParkingSpot(List<string> args)
        {
            int id = int.Parse(args[0]);
            bool occupied = bool.Parse(args[1]);
            string type = args[2];
            double price = double.Parse(args[3]);
            bool success = false;

            var spot = Spot(id);

            if (spot != null)
                return $"Parking spot {id} is already registered!";

            switch (type)
            {
                case "car":
                    CarParkingSpot car = new(id, occupied, price);
                    parkingSpots.Add(car);
                    success = true;
                    break;
                case "bus":
                    BusParkingSpot bus = new(id, occupied, price);
                    parkingSpots.Add(bus);
                    success = true;
                    break;
                case "subscription":
                    SubscriptionParkingSpot p = new(id, occupied, price, args[5]);
                    parkingSpots.Add(p);
                    success = true;
                    break;
            }
            if (success)
                return $"Parking spot {id} was successfully registered in the system!";
            else
                return "Unable to create parking spot!";
        }

        public string ParkVehicle(List<string> args)
        {
            int id = int.Parse(args[0]);
            string plate = args[1];
            int hours = int.Parse(args[2]);
            string type = args[3];

            var spot = Spot(id);
            if (spot == null)
                return $"Parking spot {id} not found!";

            if (spot.ParkVehicle(plate, hours, type))
                return $"Vehicle {plate} parked at {id} for {hours} hours.";
            else
                return $"Vehicle {plate} can't park at {id}.";
        }

        public string FreeParkingSpot(List<string> args)
        {
            int parkingSpotId = int.Parse(args[0]);
            var spot = Spot(parkingSpotId);
            if (spot == null)
                return $"Parking spot {parkingSpotId} not found!";
            if (spot.Occupied == true)
                return $"Parking spot {parkingSpotId} is not occupied.";
            spot.Occupied = false;
            return $"Parking spot {parkingSpotId} is now free!";
        }

        public string GetParkingSpotById(List<string> args)
        {
            int parkingSpotId = int.Parse(args[0]);
            var spot = Spot(parkingSpotId);
            if (spot == null)
                return $"Parking spot {parkingSpotId} not found!";
            return spot.ToString();
        }

        public string GetParkingIntervalsByParkingSpotIdAndRegistrationPlate(List<string> args)
        {
            int parkingSpotId = int.Parse(args[0]);
            string plate = args[1];
            var spot = Spot(parkingSpotId);
            if (spot == null)
                return $"Parking spot {parkingSpotId} not found!";
            var intervals = spot.GetAllParkingIntervalsByRegistrationPlate(plate);
            string result = $"Parking intervals for parking spot {parkingSpotId}:";
            foreach (var interval in intervals)
            {
                result += interval.ToString();
            }
            return result;
        }

        public string CalculateTotal(List<string> args)
        {
            var spots = parkingSpots.Where(x => x.Type != "subscription").ToList();
            double sum = spots.Sum(x => x.CalculateTotal());
            return $"Total revenue from the parking: {sum:F2} BGN";
        }

        private ParkingSpot Spot(int id)
        {
            var smth =  parkingSpots.Where(x => x.Id == id).ToList();
            if (smth.Count == 0) return null;
            return smth[0];
        }

    }


}
