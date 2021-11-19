using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_construction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Home home = new Home(4, 4);
                TeamLeader leader = new TeamLeader();
                Team team = new Team(5);
                var work = new IWorker[] { team, leader };
                foreach (IWorker w in work)
                {
                    w.buildHome(home);
                }
                Console.WriteLine();
                home.printHome();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
