using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_4_StartMVC.Services
{
    public class ValidatorKelvin : IValidatorForTemperature
    {
        const double MIN_Kelvin = 0;
        public bool Valid(double temperature)
        {
            return  temperature >= MIN_Kelvin ? true : false;
        }
    }
}
