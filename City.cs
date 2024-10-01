﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class City:IMessageWritter
    {
        private List<Taxi> taxiLicenses;
        private PoliceStation policeStation;
        private string cityName;

        public City(string name)
        {
            taxiLicenses = new List<Taxi>();
            policeStation = new PoliceStation();
            cityName = name;
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

        public override string ToString()
        {
            return "City " + cityName;
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}
