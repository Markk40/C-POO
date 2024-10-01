using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class City
    {
        private List<Taxi> taxiLicenses;
        private PoliceStation policeStation;

        public City()
        {
            taxiLicenses = new List<Taxi>();
            policeStation = new PoliceStation();
        }

        public List<Taxi> GetTaxiLicenses()
        {
            return taxiLicenses;
        }

        public void AddTaxi(Taxi taxi)
        {
            taxiLicenses.Add(taxi);
        }
        public void RemoveTaxi(Taxi taxi)
        {
            taxiLicenses.Remove(taxi);
        }
    }
}
