using System;

namespace HomeWork_4
{

    partial class Airplane
    {
        public Airplane(string name, int numCrewMembers, int numPassengerSeats,
            float cruisingSpeed, int maxAltitude, int aircraftRange)
        {
            _counter++;
            _name = name;
            _numCrewMembers = numCrewMembers;
            _numPassengerSeats = numPassengerSeats;
            _cruisingSpeed = cruisingSpeed;
            _maxAltitude = maxAltitude;
            _aircraftRange = aircraftRange;
        }

        public Airplane(string name) : this(name, 0, 0, 0, 0, 0) { }
        public Airplane() : this("", 0, 0, 0, 0, 0) { }

        private static int _counter = 0;
        private static int _maxAltitudeAll;

        static Airplane()
        {
            _maxAltitudeAll = 15000;
        }

        public static int MaxAltitudeAll
        {
            get { return _maxAltitudeAll; }
        }

        public static void DispCounter()
        {
            Console.WriteLine($"Коллекция включает {_counter} самолетов.");
        }

        private string _name;
        private int _numCrewMembers;
        private int _numPassengerSeats;
        private float _cruisingSpeed;
        private int _maxAltitude;
        private int _aircraftRange;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int NumCrewMembers
        {
            get { return _numCrewMembers; }
            set
            {
                if (value < 1) { throw new ArgumentException("Количество членов экипажа не должно быть меньше 1."); }
                else { _numCrewMembers = value; }
            }
        }

        public int NumPassengerSeats
        {
            get { return _numPassengerSeats; }
            set 
            {
                if (value < 0) { throw new ArgumentException("Число пассажирских мест не должно быть менее 0."); }
                else { _numPassengerSeats = value; }
            }
        }

        public float CruisingSpeed
        {
            get { return _cruisingSpeed; }
            set 
            {
                if (value < 0) { throw new ArgumentException("Крейсерская скрорсть не должна быть меньше ноля."); }
                else { _cruisingSpeed = value; }
            }
        }

        public int MaxAltitude
        {
            get { return _maxAltitude; }
            set 
            {
                if (value >= 0 && value <= _maxAltitudeAll) { _maxAltitude = value; }
                else 
                { 
                    if (value < 0) { throw new ArgumentException("Максимальная высота не должна быть отрицательным числом."); };
                    if (value > _maxAltitudeAll) { throw new ArgumentException("Максимальная высота не должна быть выше " + _maxAltitudeAll); };
                }
            }
        }

        public int AircraftRange
        {
            get { return _aircraftRange; }
            set 
            {
                if (value < 0) { throw new ArgumentException("Дальность полета не должна быть меньше ноля."); }
                else { _aircraftRange = value; }
            }
        }

        public void PrintAirplane()
        {
            Console.WriteLine($"Имя: {_name}");
            Console.WriteLine($"Количество членов экипажа: {_numCrewMembers}");
            Console.WriteLine($"Число мест для пассажиров: {_numPassengerSeats}");
            Console.WriteLine($"Крейсерская скорость: {_cruisingSpeed}");
            Console.WriteLine($"Максимальная высота: {_maxAltitude}");
            Console.WriteLine($"Дальность полета: {_aircraftRange}");
            Console.WriteLine();
        }

        public int FindAirplane(string name, Airplane[] airplanes)
        {
            int ind = -1;

            for (int i = 0; i < airplanes.Length; i++)
            {
                if (name == airplanes[i].Name)
                {
                    ind = i;
                    return ind;
                }
            }
            return ind;
        }

        public static void maxRange(ref int range, ref int ind, Airplane[] airplanes) {

            for (int i = 0; i < airplanes.Length; i++)
            {
                if (range < airplanes[i].AircraftRange)
                {
                    range = airplanes[i].AircraftRange;
                    ind = i;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Airplane[] airplanes =
                {
                new Airplane("Boeing 777", 2, 550, 980, 13100, 10200),
                new Airplane("TU-154", 4, 160, 800, 12200, 3600),
                new Airplane("Airbus A319", 2, 156, 850, 12500, 6845),
                new Airplane("Boeing 737", 2, 189, 825, 12400, 5660),
                new Airplane("Airbus A330", 2, 440, 840, 12500, 10800)
                };

                Console.WriteLine("Для вывода данных о самолете введите 1. " +
                    "\nДля добавления нового самолета нажмите 2." +
                    "\nДля просмотра самолета с самым дальним следованием введите 3." +
                    "\nДля просмотра информации о всех самолетах нажмите 4." +
                    "\nИмеется информация о самолетах:\n");
                foreach(Airplane elem in airplanes)
                {
                    Console.WriteLine(elem.Name);
                }

                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.WriteLine("Введите имя самолета:");
                        string air = Console.ReadLine();
                        int ind = airplanes[0].FindAirplane(air, airplanes);
                        if (ind == -1)
                        {
                            Console.WriteLine("Информации о таком самолете нет.");
                        }
                        else
                        {
                            airplanes[ind].PrintAirplane();
                        }
                        break;
                    case "2":
                        Array.Resize(ref airplanes, airplanes.Length + 1);
                        airplanes[airplanes.Length - 1] = new Airplane();
                        airplanes[airplanes.Length - 1].AddAirplane();
                        Console.WriteLine("Информация о всех имеющихся самолетах:");
                        foreach (Airplane elem in airplanes)
                        {
                            elem.PrintAirplane();
                        }
                        break;
                    case "3":
                        int res = 0;
                        int i = 0;
                        Airplane.maxRange(ref res, ref i, airplanes);
                        Console.WriteLine($"Самолет с самым дальним следованием (из имеющихся) {res} км.");
                        airplanes[i].PrintAirplane();
                        break;
                    default:
                        Console.WriteLine("Информация о всех имеющихся самолетах:\n");
                        foreach(Airplane elem in airplanes)
                        {
                            elem.PrintAirplane();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
