using System;


namespace HomeWork_4
{
    partial class Airplane
    {
        public void AddAirplane()
        {
            Console.WriteLine("Введите имя самолета.");
            Name = Console.ReadLine();
            Console.WriteLine("Введите количество членов экипажа.");
            NumCrewMembers = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число мест для пассажиров.");
            NumPassengerSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите крейсерскую скорость самолета.");
            CruisingSpeed = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальную высоту.");
            MaxAltitude = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите дальность полета.");
            AircraftRange = int.Parse(Console.ReadLine());
        }
    }
}
