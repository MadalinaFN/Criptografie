using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CifPlayfair();

            //CifVigenere();

            //*CifVernam*//
            /*int precision = 200;
            if (args.Length > 0)
                if (!int.TryParse(args[0], out precision))
                    precision = 200;

            Console.WriteLine("Input message:");
            string message = Console.ReadLine();

            Stopwatch s = new Stopwatch();
            s.Start();

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] keyBytes = KeyGenerator.GenerateKey(messageBytes.Length, precision);
            byte[] outputBytes = new byte[messageBytes.Length];

            for (int i = 0; i < messageBytes.Length; i++)
                outputBytes[i] = (byte)(messageBytes[i] ^ keyBytes[i]);
            string encryptedMessage = Encoding.UTF8.GetString(outputBytes);

            Console.WriteLine("\nENCRYPTED MESSAGE:\n {0}", encryptedMessage);

            for (int i = 0; i < messageBytes.Length; i++)
                messageBytes[i] = (byte)(outputBytes[i] ^ keyBytes[i]);
            message = Encoding.UTF8.GetString(messageBytes);

            Console.WriteLine("\nDECRYPTED MESSAGE:\n {0}", message);

            s.Stop();
            Console.WriteLine("\nDone in {0}ms", s.ElapsedMilliseconds);

            Console.ReadLine();*/
        }

        private static void CifPlayfair()
        {
            Console.Write("Key: ");
            var key = Console.ReadLine().ToLower();
            var playfair = new Cifrul_Playfair();
            Console.Write("text: ");
            string txt = Console.ReadLine().ToLower();

            playfair.SetKey(key);
            playfair.KeyGen();
            string e = "";
            if (txt.Length % 2 == 0)
            {
                e = playfair.EncryptMessage(txt);

                Console.WriteLine("Encryption: " + e);
            }
            else
            {
                txt = txt + 'x';
                e = playfair.EncryptMessage(txt);
            }

            Console.WriteLine("Decryption: " + playfair.DecryptMessage(e));
        }

        private static void CifVigenere()
        {
            string text, cuvantcheie, cheie, textcv;
            text = "ATTACKATDAWN";
            Cifrul_Vigenere cv = new Cifrul_Vigenere();

            Console.Write("Cuvantul cheie:");
            cuvantcheie = Console.ReadLine();

            cheie = cv.Crearecheie(cuvantcheie, text);
            Console.WriteLine("Cheia generata este:{0}", cheie);
            textcv = cv.Criptare(cheie, text);
            Console.Write("Textul criptat este:{0}", textcv);
            Console.WriteLine();
            Console.Write("Textul decriptat este:"); cv.Decriptare(textcv, cheie);
            Console.WriteLine();
        }
    }
}
