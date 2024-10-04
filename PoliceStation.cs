using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class PoliceStation : IMessageWritter
    {
        private List<PoliceCar> registeredCars;
        private bool alarm;
        private string name;

        public PoliceStation(string name)
        {
            alarm = false;
            registeredCars = new List<PoliceCar>();
            this.name = name;
        }

        public void RegisterCar(PoliceCar car)
        {
            registeredCars.Add(car);
        }
        private void NotifyPoliceCars(string plate)
        {
            foreach (PoliceCar car in registeredCars)
            {
                if (car.IsPatrolling())
                {
                    car.SetChasedVehicle(plate);
                }
            }
        }

        public void ActivateAlarm(string plate)
        {
            alarm = true;
            Console.WriteLine(WriteMessage($"Alarm activated. Alerting to chase vehicle with plate {plate}"));
            NotifyPoliceCars(plate);
        }

        public override string ToString()
        {
            return "Station " + name;
        }

        public virtual string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }

    }


}
