using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_4_StartMVC.Services
{
    public class ConvertToFahrenheit : ITemperatureConverter
    {
        public string Name { get; set; }
        public string ConvertDirection { get; set; }
        public ConvertToFahrenheit()
        {
            Name = "C";
            ConvertDirection = "F";
        }
        public double Convert(double temp)
        {
            return temp*9/5 +32;
        }
    }
}
