using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Изпит_Модул_5
{
    internal class SubscriptionParkingSpot : ParkingSpot
    {
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

        public SubscriptionParkingSpot(int id, bool occupied, double price, string registrationPlate) : base(id, occupied, "subscription", price)
        {
            RegistrationPlate = registrationPlate;
        }

        public override bool ParkVehicle(string registrationPlate, int hoursParked, string type)
        {
            return base.ParkVehicle(registrationPlate, hoursParked, type);
        }

        public override double CalculateTotal()
        {
            return base.CalculateTotal();
        }
    }


}
