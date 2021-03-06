using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_2
{
    class KeyGenerator
    {
        public static byte[] GenerateKey(int length, int precision)
        {
            int bytesLeft = length - 1;
            byte[] output = new byte[length];

            BBSRandom random = new BBSRandom(precision);
            byte[] temp;
            while (bytesLeft > 0)
            {
                temp = random.Next().ToByteArray();
                foreach (byte b in temp)
                {
                    output[bytesLeft--] = b;
                    if (bytesLeft < 0)
                        break;
                }
            }
            return output;
        }
    }
}
