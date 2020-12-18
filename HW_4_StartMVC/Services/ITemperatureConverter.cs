using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_4_StartMVC.Services
{
    public interface ITemperatureConverter
    {
        public string Name { get; set; }
        public string ConvertDirection { get; set; }
        public double Convert(double temp);
    }
}
