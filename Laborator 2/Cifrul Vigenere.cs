using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_2
{
    class Cifrul_Vigenere
    {
        public string Crearecheie(string cuvantcheie, string text)
        {
            StringBuilder s = new StringBuilder();
            while (s.Length != text.Length)
                foreach (char x in cuvantcheie)
                    if (s.Length == text.Length) break;
                    else s.Append(x);
            return s.ToString();
        }
        public string Criptare(string cheie, string text)
        {
            string textcriptat = "";
            for (int i = 0; i < text.Length; i++)
            {
                int litera = (text[i] + cheie[i]) % 26;
                litera = litera + 'A';
                textcriptat = textcriptat + (char)litera;
            }
            return textcriptat;
        }
        public void Decriptare(string textcv, string cheie)
        {
            string text = "";
            for (int i = 0; i < textcv.Length; i++)
            {
                int litera = (textcv[i] - cheie[i] + 26) % 26;
                litera = litera + 'A';
                text = text + (char)litera;
            }
            Console.Write(text);
        }
    }
}
