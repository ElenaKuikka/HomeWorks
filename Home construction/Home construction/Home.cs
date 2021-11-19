using System;
using System.IO;
using System.Threading.Tasks;

namespace Home_construction
{
    public class Home
    {
        private readonly Basement _basement;
        private readonly Walls[] _walls;
        private readonly Door _door;
        private readonly Window[] _windows;
        private readonly Roof _roof;
        private bool _isBuilt;

        public Home(int wallsCount, int windowCount)
        {
            _basement = new Basement();
            _walls = new Walls[wallsCount];
            for (int i = 0; i < wallsCount; i++)
            {
                _walls[i] = new Walls();
            }

            _door = new Door();

            _windows = new Window[windowCount];
            for (int i = 0; i < windowCount; i++)
            {
                _windows[i] = new Window();
            }

            _roof = new Roof();
            _isBuilt = false;
        }

        public Basement HomeBasement => _basement;
        public Walls[] HomeWalls => _walls;
        public Door HomeDoor => _door;
        public Window[] HomeWindows => _windows;
        public Roof HomeRoof => _roof;

        public bool IsBuilt
        {
            get { return _isBuilt; }
            set { _isBuilt = value; }
        }


        public bool wallsIsReady() 
        {
            bool isReady = false;
            foreach (Walls w in _walls)
            {
                isReady = w.isReady();
                if (!isReady)
                {
                    return isReady;
                }
            }
            return isReady;
        }

        public bool windowsIsReady()
        {
            bool isReady = false;
            foreach (Window w in _windows)
            {
                isReady = w.isReady();
                if (!isReady)
                {
                    return isReady;
                }
            }
            return isReady;
        }

        public void printHome() {
            if (_isBuilt)
            {
                string path = @"C:\Users\Bazavr\Desktop\IT\Домашняя работа\ООП С++\Git\Home construction\Home construction\home.txt";

                using (StreamReader s = new StreamReader(path))
                {
                    Console.WriteLine(s.ReadToEnd());
                }
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
