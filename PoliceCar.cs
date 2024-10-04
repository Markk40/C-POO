using System.Diagnostics.Metrics;

namespace Practice1
{
    class PoliceCar : PlateVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        private bool isChasing;
        private string chasedVehiclePlate;
        private PoliceStation station;


        public PoliceCar(string plate, bool hasRadar, PoliceStation station) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            if (hasRadar)
            {
                speedRadar = new SpeedRadar();
            }
            else
            {
                speedRadar = null;
            }
            isChasing = false;
            chasedVehiclePlate = "";
            this.station = station;
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (speedRadar.GetInfracion())
                    {
                        if (vehicle is PlateVehicle plateVehicle)
                        {
                            this.AlertStation(plateVehicle.GetPlate());
                        }
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage($"has no radar."));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar == null)
            {
                Console.WriteLine(WriteMessage($"has no radar."));
            }
            else
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
        }
        private void AlertStation(string plate)
        {
            station.ActivateAlarm(plate);
        }
        public void SetChasedVehicle(string plate)
        {
            if (!isChasing)
            {
                chasedVehiclePlate = plate;
                isChasing = true;
                Console.WriteLine($"{this}: Started chasing vehicle with plate {plate}");
            }

        }
    }
}