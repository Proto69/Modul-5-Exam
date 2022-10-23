using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Изпит_Модул_5
{
    public abstract class ParkingSpot
    {
        private int id;
        private bool occupied;
        private string type;
        private double price;
        protected List<ParkingInterval> parkingIntervals;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool Occupied
        {
            get
            {
                return occupied;
            }

            set
            {
                occupied = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }

        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("Parking price cannot be less or equal to 0!");
                price = value;
            }
        }

        public ParkingSpot(int id, bool occupied, string type, double price)
        {
            Id = id;
            Occupied = occupied;
            Type = type;
            Price = price;
            parkingIntervals = new List<ParkingInterval>();
        }

        public virtual bool ParkVehicle(string registrationPlate, int hoursParked, string type)
        {
            if (Occupied || Type != type)
                return false;
            ParkingInterval parkingInterval = new(this, registrationPlate, hoursParked);
            parkingIntervals.Add(parkingInterval);
            return true;
        }

        public List<ParkingInterval> GetAllParkingIntervalsByRegistrationPlate(string registrationPlate)
        {
            List<ParkingInterval> list = new();
            list = parkingIntervals.Where(x => x.RegistrationPlate == registrationPlate).ToList();
            return list;
        }

        public virtual double CalculateTotal()
        {
            double total = 0;
            foreach (var item in parkingIntervals)
            {
                total += item.Revenue;
            }
            return total;
        }

        public override string ToString()
        {
            string result = $"> Parking Spot #{Id}\n> Occupied: {!Occupied}\n> Type: {Type}\n> Price per hour: {Price:F2} BGN";
            return result;
        }

    }

}
