﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleTrack_Console {
    internal class Tracker {

        private List<Period> periods = new List<Period>();

        public void AddHistory(Period period) {
            periods.Add(period);
            SaveData();
        }

        public Period CalculateNext() {
            return new Period();
        }

        private void SaveData() {
            string data = JsonConvert.SerializeObject(periods);
            File.WriteAllText("periods.txt", data);
        }

        private void LoadData() { 
            if (File.Exists("periods.txt")) {
                string data = File.ReadAllText("periods.txt");
                periods = JsonConvert.DeserializeObject<List<Period>>(data);
            }
        }
    }
}
