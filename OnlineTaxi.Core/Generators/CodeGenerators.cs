using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTaxi.Core.Generators
{
    public static class CodeGenerators
    {
        static Random rnd = new Random();
        public static string GetActiveCode()
        {
            return rnd.Next(1000000, 999999999).ToString();
        }

        public static Guid GetId()
        {
            return Guid.NewGuid();
        }

        public static string GetFileName()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public static string GetOrderCode()
        {
            return rnd.Next(10000000, 999999999).ToString();
        }
    }
}
