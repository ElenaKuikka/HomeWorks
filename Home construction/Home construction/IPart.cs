using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_construction
{
    public interface IPart
    {
        void Build();
        bool isReady();
        void printStatus();
    }

    public class Basement : IPart
    {
        private bool _isBasementBuilt;
        public Basement() { _isBasementBuilt = false; }

        public void Build() { _isBasementBuilt = true; }

        public bool isReady() => _isBasementBuilt;

        public void printStatus()
        {
            if (_isBasementBuilt)
            {
                Console.WriteLine("Фундамент построен!");
            }
            else
            {
                Console.WriteLine("Фундамент отсутствует!");
            }
        }
    }

    public class Walls : IPart
    {
        private bool _isWallsBuilt;
        public Walls() { _isWallsBuilt = false; }

        public void Build() { _isWallsBuilt = true; }

        public bool isReady() => _isWallsBuilt;

        public void printStatus()
        {
            if (_isWallsBuilt)
            {
                Console.WriteLine("Стена построена!");
            }
            else
            {
                Console.WriteLine("Стена отсутствует!");
            }
        }
    }

    public class Door : IPart 
    {
        private bool _isDoorBuilt;
        public Door() { _isDoorBuilt = false; }

        public void Build() { _isDoorBuilt = true; }

        public bool isReady() => _isDoorBuilt;

        public void printStatus()
        {
            if (_isDoorBuilt)
            {
                Console.WriteLine("Дверь построена!");
            }
            else
            {
                Console.WriteLine("Дверь отсутствует!");
            }
        }
    }

    public class Window : IPart 
    {
        private bool _isWindowBuilt;
        public Window() { _isWindowBuilt = false; }

        public void Build() { _isWindowBuilt = true; }

        public bool isReady() => _isWindowBuilt;

        public void printStatus()
        {
            if (_isWindowBuilt)
            {
                Console.WriteLine("Окно построено!");
            }
            else
            {
                Console.WriteLine("Окно отсутствует!");
            }
        }
    }

    public class Roof : IPart 
    {
        private bool _isRoofBuilt;
        public Roof() { _isRoofBuilt = false; }

        public void Build() { _isRoofBuilt= true; }

        public bool isReady() => _isRoofBuilt;

        public void printStatus()
        {
            if (_isRoofBuilt)
            {
                Console.WriteLine("Крыша построена!");
            }
            else
            {
                Console.WriteLine("Крыша отсутствует!");
            }
        }
    }

}
