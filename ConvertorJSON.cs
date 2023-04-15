using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TemaXIS
{
    class ConvertorJSON
    {
        public string jsonPath { get; }
        public Bike_Rent bike_rent { get; set; }

        public ConvertorJSON(string path)
        {
            jsonPath = path;
            bike_rent = new Bike_Rent();
        }
        public void Convert()
        {
            string jsonString = File.ReadAllText(jsonPath);
            bike_rent = JsonSerializer.Deserialize<Bike_Rent>(jsonString);
        }
    }
}
