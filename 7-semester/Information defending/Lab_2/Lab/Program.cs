using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Program
    {
        static List<char> alphabet = new List<char>();
        static char ShiftChar(char old_char, int shift)
        {
            int pos = alphabet.FindIndex(x => x == old_char);
            int shift_in_border = shift % alphabet.Count;

            if (pos + shift_in_border < 0)
                pos = alphabet.Count - Math.Abs(pos + shift_in_border);

            else if (pos + shift_in_border >= alphabet.Count)
                pos = Math.Abs(pos + shift_in_border - alphabet.Count);
            else
                pos += shift_in_border;

            return alphabet[pos];
        }
        static void Main(string[] args)
        {
            char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
            char[] AZ = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();
            foreach (char c in az)
                alphabet.Add(c);

            foreach (char c in AZ)
                alphabet.Add(c);

            alphabet.Add(' ');
            alphabet.Add('.');
            alphabet.Add('!');
            alphabet.Add(',');

            CryptographyPrinciple principle;
            CryptographyMode mode;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Press Esc to close");
                Console.WriteLine("Press 'Something else' to continue");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                    return;
                
                if(ChooseCryptography(out principle))
                    if(ChooseMode(out mode))
                    {
                        string new_text = "";
                        if (mode == CryptographyMode.Encryption)
                            new_text = Encryption(principle);
                        else if (mode == CryptographyMode.Decryption)
                            new_text = Decryption(principle);

                        Console.Write(new_text);

                        Console.ReadKey();
                    }

            }
        }
        static bool ChooseCryptography(out CryptographyPrinciple mode)
        {
            Console.Clear();

            Console.WriteLine("1) Vizhener");
            Console.WriteLine("2) Tcezar");

            Console.Write("Choose Cryptography Mode: ");
            string input = Console.ReadLine();


            switch (input)
            {
                case "1":
                    mode = CryptographyPrinciple.Vizhener;
                    return true;

                case "2":
                    mode = CryptographyPrinciple.Tcezar;
                    return true;

                default:
                    mode = CryptographyPrinciple.None;
                    return false;
            }
        }
        static bool ChooseMode(out CryptographyMode mode)
        {
            Console.Clear();

            Console.WriteLine("1) Encryption");
            Console.WriteLine("2) Decryption");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    mode = CryptographyMode.Encryption;
                    return true;
                case "2":
                    mode = CryptographyMode.Decryption;
                    return true;
                default:
                    mode = CryptographyMode.None;
                    return false;
            }
        }
        static string Encryption(CryptographyPrinciple mode)
        {
            Console.Clear();

            string text;

            Console.WriteLine("Type in your string");
            text = Console.ReadLine();



            if (mode == CryptographyPrinciple.Vizhener)
                return VizhenerEncryption(text);
            else if (mode == CryptographyPrinciple.Tcezar)
                return TcezarEncryption(text);

            return "";
        }
        static string Decryption(CryptographyPrinciple mode)
        {
            Console.Clear();

            string text;

            Console.WriteLine("Type in your string");
            text = Console.ReadLine();

            if (mode == CryptographyPrinciple.Vizhener)
                return VizhenerDecryption(text);
            else if (mode == CryptographyPrinciple.Tcezar)
                return TcezarDecryption(text);

            return "";
        }
        static string VizhenerEncryption(string text)
        {
            Console.Clear();

            Console.WriteLine("Type in your key");
            string typing = Console.ReadLine();

            string result = "";
            string buff_result = text;


            foreach (char key_ch in typing)
            {
                result = "";
                

                foreach (char ch in buff_result)
                    result += ShiftChar(ch, alphabet.FindIndex(x => x == key_ch));

                buff_result = result;
            }


            return result;
        }
        static string VizhenerDecryption(string text)
        {
            Console.Clear();

            Console.WriteLine("Type in your key");
            string typing = Console.ReadLine();

            string result = "";
            string buff_result = text;


            foreach (char key_ch in typing)
            {
                result = "";


                foreach (char ch in buff_result)
                    result += ShiftChar(ch, -alphabet.FindIndex(x => x == key_ch));

                buff_result = result;
            }


            return result;
        }
        static string TcezarEncryption(string text)
        {
            Console.Clear();

            Console.WriteLine("Type in your shift");
            string typing = Console.ReadLine();
            int shift = -1;

            try
            {
                shift = int.Parse(typing);
            }
            catch
            {
                return "Not cool, man o_o ";
            }

            string result = "";

            foreach(char ch in text)
                result += ShiftChar(ch, shift);

            return result;
        }
        static string TcezarDecryption(string text)
        {
            Console.Clear();

            Console.WriteLine("Type in your shift");
            string typing = Console.ReadLine();
            int shift = -1;

            try
            {
                shift = int.Parse(typing);
            }
            catch
            {
                return "Not cool, man o_o ";
            }

            string result = "";

            foreach (char ch in text)
                result += ShiftChar(ch, -shift);

            return result;
        }

        enum CryptographyMode
        {
            None,
            Encryption,
            Decryption
        }
        enum CryptographyPrinciple
        {
            None,
            Vizhener,
            Tcezar
        }
    }
}
