using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDfromBinary
{
    class Program
    {
        static int Main(string[] args)
        {
            byte[] sid;
            try
            {
                //sid = StringToByteArray("0x010600000000000550000000E20F4FE7B15874E48E19026478C2DC9AC307B83E");
                sid = StringToByteArray(args[0]);
            }
            catch(Exception ex) 
            {
                Console.WriteLine("введённая hex строка не переводится двоичные данные");
                Console.WriteLine(ex.Message);
                return 1;
            }
            try
            {
                var t = new System.Security.Principal.SecurityIdentifier(sid, 0);
                Console.WriteLine(t.Value);
            }
            catch(Exception ex) 
            {
                Console.WriteLine("введённая hex строка не переводится двоичные данные");
                Console.WriteLine(ex.Message);
                return 2;
            }
            return 0;
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
