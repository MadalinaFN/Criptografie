using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_2
{
    class Cifrul_Playfair
    {
        private string KeyWord = "";
        private string Key = "";
        private char[][] matrix_arr = new char[5][];

        public Cifrul_Playfair()
        {
            for (int i = 0; i < 5; i++)
                matrix_arr[i] = new char[5];
        }

        public void SetKey(string k)
        {
            string K_adjust = "";
            bool flag = false;
            K_adjust = K_adjust + k[0];

            for (int i = 1; i < k.Length; i++)
            {
                for (int j = 0; j < K_adjust.Length; j++)
                {
                    if (k[i] == K_adjust[j])
                        flag = true;
                }

                if (flag == false)
                    K_adjust = K_adjust + k[i];

                flag = false;
            }
            KeyWord = K_adjust;
        }

        public void KeyGen()
        {
            bool flag = true;
            char current;
            Key = KeyWord;

            for (int i = 0; i < 26; i++)
            {
                current = (char)(i + 97);

                if (current == 'j')
                    continue;

                for (int j = 0; j < KeyWord.Length; j++)
                {
                    if (current == KeyWord[j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    Key = Key + current;

                flag = true;
            }
            Matrix();
        }

        private void Matrix()
        {
            int counter = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix_arr[i][j] = Key[counter];
                    Console.Write(matrix_arr[i][j] + " ");
                    counter++;
                }
                Console.WriteLine();
            }
        }

        private string Format(string old_text)
        {
            int i = 0;
            int len = 0;
            string text = "";
            len = old_text.Length;

            for (int tmp = 0; tmp < len; tmp++)
            {
                if (old_text[tmp] == 'j')
                    text = text + 'i';
                else
                    text = text + old_text[tmp];
            }

            len = text.Length;

            for (i = 0; i < len; i = i + 2)
            {
                if (text[i + 1] == text[i])
                    text = text.Substring(0, i + 1) + 'x' + text.Substring(i + 1);
            }
            return text;
        }

        private string[] Divid2Pairs(string new_string)
        {
            string Original = Format(new_string);
            int size = Original.Length;
            if (size % 2 != 0)
            {
                size++;
                Original = Original + 'x';
            }

            string[] x = new string[size / 2];
            int counter = 0;

            for (int i = 0; i < size / 2; i++)
            {
                x[i] = Original.Substring(counter, 2);
                counter += 2;
            }
            return x;
        }

        public int[] GetDiminsions(char letter)
        {
            int[] key = new int[2];
            if (letter == 'j')
                letter = 'i';

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix_arr[i][j] == letter)
                    {
                        key[0] = i;
                        key[1] = j;
                        break;
                    }
                }
            }
            return key;
        }

        public string EncryptMessage(string Source)
        {
            string[] src_arr = Divid2Pairs(Source);
            string Code = "";
            char one;
            char two;
            int[] part1 = new int[2];
            int[] part2 = new int[2];

            for (int i = 0; i < src_arr.Length; i++)
            {
                one = src_arr[i][0];
                two = src_arr[i][1];
                part1 = GetDiminsions(one);
                part2 = GetDiminsions(two);

                if (part1[0] == part2[0])
                {
                    if (part1[1] < 4)
                        part1[1]++;
                    else
                        part1[1] = 0;

                    if (part2[1] < 4)
                        part2[1]++;
                    else
                        part2[1] = 0;

                }
                else if (part1[1] == part2[1])
                {

                    if (part1[0] < 4)
                        part1[0]++;
                    else
                        part1[0] = 0;

                    if (part2[0] < 4)
                        part2[0]++;
                    else
                        part2[0] = 0;

                }
                else
                {
                    int temp = part1[1];
                    part1[1] = part2[1];
                    part2[1] = temp;
                }
                Code = Code + matrix_arr[part1[0]][part1[1]] + matrix_arr[part2[0]][part2[1]];
            }
            return Code;
        }

        public string DecryptMessage(string Code)
        {
            string Original = "";
            string[] src_arr = Divid2Pairs(Code);
            char one;
            char two;
            int[] part1 = new int[2];
            int[] part2 = new int[2];

            for (int i = 0; i < src_arr.Length; i++)
            {
                one = src_arr[i][0];
                two = src_arr[i][1];
                part1 = GetDiminsions(one);
                part2 = GetDiminsions(two);

                if (part1[0] == part2[0])
                {
                    if (part1[1] > 0)
                        part1[1]--;
                    else
                        part1[1] = 4;

                    if (part2[1] > 0)
                        part2[1]--;
                    else
                        part2[1] = 4;
                }
                else if (part1[1] == part2[1])
                {
                    if (part1[0] > 0)
                        part1[0]--;
                    else
                        part1[0] = 4;

                    if (part2[0] > 0)
                        part2[0]--;
                    else
                        part2[0] = 4;
                }
                else
                {
                    int temp = part1[1];
                    part1[1] = part2[1];
                    part2[1] = temp;
                }
                Original = Original + matrix_arr[part1[0]][part1[1]] + matrix_arr[part2[0]][part2[1]];
            }
            return Original;
        }
    }
}
