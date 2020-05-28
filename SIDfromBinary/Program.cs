using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDfromBinary
{
    class Program
    {
        static void Main(string[] args)
        {

            byte [] sid = StringToByteArray("0x010600000000000550000000E20F4FE7B15874E48E19026478C2DC9AC307B83E");

            var t = new System.Security.Principal.SecurityIdentifier(sid, 0);
        }

        public static byte[] StringToByteArray(string hex)
        {
            string trimmedhex = hex.Replace("0x", "");

            return Enumerable.Range(0, trimmedhex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(trimmedhex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
