using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    public class FigureException : Exception
    {
        public const string ArgumentLessOrEqualThanZeroMessage = "Аргумент меньше или равен 0";

        public static bool IsLessOrEqualThanZero(int a)
        {
            if (a <= 0) 
                return true;
            else
                return false;
        }
    }
}
