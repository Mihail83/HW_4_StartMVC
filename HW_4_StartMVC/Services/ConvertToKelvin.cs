using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_4_StartMVC.Services
{
    public class ConvertToKelvin : ITemperatureConverter
    {
        public string Name { get; set; }
        public string ConvertDirection { get; set; }
        public ConvertToKelvin()
        {
            Name = "C";
            ConvertDirection = "K";
        }

        public double Convert(double temp)
        {
            return temp-273.15;
        }
    }
}
