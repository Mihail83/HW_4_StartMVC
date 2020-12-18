using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_4_StartMVC.Services
{
    public interface IValidatorForTemperature
    {
        public bool Valid(double temperature);
    }
}
