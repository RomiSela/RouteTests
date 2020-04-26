using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // TODO: name too generic. this is a generator for fields.
    public class Generate
    {
        public static int GenerateA5DigitsNumber()
        {
            Random rnd = new Random();
            return  rnd.Next(10000, 99999);
        }
    }
}
