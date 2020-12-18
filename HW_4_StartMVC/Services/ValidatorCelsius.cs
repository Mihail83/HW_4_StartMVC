using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_4_StartMVC.Services
{
    public class ValidatorCelsius : IValidatorForTemperature
    {
        const double MIN_Celsius = -373.3;
        public bool Valid(double temperature)
        {
            return temperature >= MIN_Celsius ? true:false;
        }
    }
}
