using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleTrack_Console {
    internal class App {
        static void Main(string[] args) {

            Initialize();

            Console.WriteLine("|-------------------------|");
            Console.WriteLine("| Cycle Tracker / (1.0.0) |");
            Console.WriteLine("|-------------------------|\n");
        }

        static void Initialize() {
            Tracker tracker = new Tracker();
            tracker.LoadData();
        }
    }
}
