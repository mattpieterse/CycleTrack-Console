using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CycleTrack_Console {
    internal class App {

        static Tracker tracker = new Tracker();

        static void Main(string[] args) {

            tracker.LoadData();

            Console.WriteLine("|-------------------------|");
            Console.WriteLine("| Cycle Tracker / (1.0.0) |");
            Console.WriteLine("|-------------------------|");

            Menu();
        }

        static void Menu() {
            int userDestination = 0;
            do {
                Console.WriteLine();
                Console.WriteLine("[ 1 ]: Log recent cycle");
                Console.WriteLine("[ 2 ]: View history of cycles");
                Console.WriteLine("[ 3 ]: Calculate next period");
                Console.WriteLine("[ 4 ]: Exit application");
                Console.Write(">> ");

                try {
                    userDestination = Convert.ToInt32(Console.ReadLine());
                }
                catch {
                    Menu();
                }

                Console.WriteLine();

                switch (userDestination) {
                    case (1):
                        Period periodNew = LogCycleData();
                        tracker.AddHistory(periodNew);
                        break;
                    case (2):
                    foreach (Period period in tracker.periods) {
                        Console.WriteLine("Cycle History:");
                        Console.WriteLine($"[ {period.startDate:dd/MM/yyyy} -> {period.endDate:dd/MM/yyyy} ]");
                    }
                    break;
                    case (3):
                    Period prediction = tracker.CalculateNext();
                    if (prediction != null) {
                        Console.WriteLine("Cycle Forecast:");
                        Console.WriteLine($"Start -> {prediction.startDate:dd/MM/yyyy}");
                        Console.WriteLine($"Until -> {prediction.endDate:dd/MM/yyyy}");
                    } else {
                        Console.WriteLine("Track more cycles for accurate prediction.");
                    }
                    break;
                }
            } while (userDestination != 4);
        }

        static Period LogCycleData() {
            try {
                Console.WriteLine("Cycle Entry:");

                Console.Write("Started >> ");
                DateTime start = DateTime.Parse(Console.ReadLine());

                Console.Write("Ended >> ");
                DateTime end = DateTime.Parse(Console.ReadLine());

                return new Period {
                    startDate = start,
                    endDate = end
                };
            } catch (FormatException) {
                Console.WriteLine("\nEnter a correct date format.");
                return LogCycleData();
            }
        }
    }
}
