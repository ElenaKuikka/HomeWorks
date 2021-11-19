using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_construction
{
    public interface IWorker
    {
        void buildHome(Home home);
        void buildBasement(Home home);
        void buildWalls(Home home);
        void buildDoor(Home home);
        void buildWindows(Home home);
        void buildRoof(Home home);
    }

    public class Worker
    {
        private static int _workerCount;
        
        public Worker()
        {
            _workerCount++;
        }

        static Worker()
        {
            _workerCount = 0;
        }

        public int WorkerCount => _workerCount;
    }

    public class TeamLeader : IWorker
    {
        public void buildHome(Home home)
        {
            buildBasement(home);
            buildWalls(home);
            buildDoor(home);
            buildWindows(home);
            buildRoof(home);
        }

        public void buildBasement(Home home)
        {
            home.HomeBasement.printStatus();
        }

        public void buildWalls(Home home)
        {
            foreach (Walls w in home.HomeWalls)
            {
                w.printStatus();
            }
        }

        public void buildDoor(Home home)
        {
            home.HomeDoor.printStatus();
        }

        public void buildWindows(Home home)
        {
            foreach (Window w in home.HomeWindows)
            {
                w.printStatus();
            }
        }

        public void buildRoof(Home home)
        {
            home.HomeRoof.printStatus();
        }
    }

    public class Team : IWorker
    {
        private readonly Worker[] _workers;

        public Team(int workerCount)
        {
            _workers = new Worker[workerCount];
        }

        public void buildHome(Home home)
        {
            buildBasement(home);
            buildWalls(home);
            buildDoor(home);
            buildWindows(home);
            buildRoof(home);
        }

        public void buildBasement(Home home)
        {
            home.HomeBasement.Build();
        }

        public void buildWalls(Home home)
        {
            if (home.HomeBasement.isReady())
            {
                for (int i = 0; i < home.HomeWalls.Length; i++) {
                    home.HomeWalls[i].Build();
                }
            }
            else
            {
                throw new Exception("Не выполнены условия для строительства стен.");
            }
        }

        public void buildDoor(Home home)
        {
            if (home.HomeBasement.isReady()&&home.wallsIsReady())
            {
                home.HomeDoor.Build();
            }
            else
            {
                throw new Exception("Не выполнены условия для строительства дверей.");
            }
        }

        public void buildWindows(Home home)
        {
            if (home.HomeBasement.isReady() && home.wallsIsReady() && home.HomeDoor.isReady())
            {
                for (int i = 0; i < home.HomeWindows.Length; i++)
                {
                    home.HomeWindows[i].Build();
                }
            }
            else
            {
                throw new Exception("Не выполнены условия для строительства окон.");
            }
        }

        public void buildRoof(Home home)
        {
            if (home.HomeBasement.isReady() && home.wallsIsReady() && home.HomeDoor.isReady() && home.windowsIsReady())
            {
                home.HomeRoof.Build();
            }
            else
            {
                throw new Exception("Не выполнены условия для строительства крыши.");
            }

            home.IsBuilt = true;
        }

    }
}
