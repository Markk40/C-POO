﻿namespace Practice1
{
    class SpeedRadar : IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        private bool infraction;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
            infraction = false;
        }

        public void TriggerRadar(Vehicle vehicle)
        {
            if (vehicle is PlateVehicle plateVehicle)
            {
                plate = plateVehicle.GetPlate();
            }
            else 
            { 
                plate = ""; 
            }

            speed = vehicle.GetSpeed();
            SpeedHistory.Add(speed);
            infraction = speed > legalSpeed;
        }
        
        public string GetLastReading()
        {
            if (infraction)
            {
                return WriteMessage("Catched above legal speed.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }

        public bool GetInfracion()
        { 
            return infraction; 
        }

        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }

    }
}