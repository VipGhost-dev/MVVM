using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    internal class Model
    {
        public static string FirstNumber;
        public static string SecondNumber;
        public static List<string> Symbols = new List<string> { "Сложение", "Вычитание", "Умножение", "Деление" };
        public static List<string> CharSymbols = new List<string> { "+", "-", "*", "/" };
        public static string result = "";
        public static int comboIndex = -1;
    }
}
