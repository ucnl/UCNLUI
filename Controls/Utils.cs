using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCNLUI.Controls
{
    public static class Utils
    {
        public static double FitAxisStepByRange(double range)
        {
            double x = Math.Pow(10.0, Math.Floor(Math.Log10(range)));
            if (range / x >= 5)
                return x;
            else if (range / (x / 2.0) >= 5)
                return x / 2.0;
            else
                return x / 5.0;
        }      

    }
}
