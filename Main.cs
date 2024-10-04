namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            PoliceStation station1 = new PoliceStation("Station 1");
            City city1 = new City("Madrid", station1);
           
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP",true,station1);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", true, station1);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", false, station1);


            Console.WriteLine(city1.WriteMessage("Created"));
            Console.WriteLine(station1.WriteMessage($"Created and added to city {city1}"));
            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created with radar"));
            Console.WriteLine(policeCar2.WriteMessage("Created with radar"));
            Console.WriteLine(policeCar3.WriteMessage("Created"));

            city1.AddTaxi(taxi1);
            city1.AddTaxi(taxi2);

            Console.WriteLine(city1.WriteMessage($"{taxi1} license added"));
            Console.WriteLine(city1.WriteMessage($"{taxi2} license added"));

            station1.RegisterCar(policeCar1);
            station1.RegisterCar(policeCar2);
            station1.RegisterCar(policeCar3);

            Console.WriteLine(station1.WriteMessage($"{policeCar1} registered"));
            Console.WriteLine(station1.WriteMessage($"{policeCar2} registered"));
            Console.WriteLine(station1.WriteMessage($"{policeCar3} registered"));


            policeCar1.StartPatrolling();
            policeCar2.StartPatrolling();
            policeCar3.StartPatrolling();

            policeCar3.UseRadar(taxi1);

            policeCar1.UseRadar(taxi1);

            taxi1.StartRide();
            policeCar1.UseRadar(taxi1);

            taxi1.StopRide();
            city1.RemoveTaxi(taxi1);
            Console.WriteLine(city1.WriteMessage($"{taxi1} license removed"));


        }
    }
}
    

