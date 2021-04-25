using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Matrix
{
    class Program
    {
        static string FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/False.txt";

        static Dictionary<string, string> FalseWords = new Dictionary<string, string>
        {
            ["превет"] = "привет",
            ["превет,"] = "привет,",

            ["ихний"] = "их",
            ["ихний,"] = "их,"

        };

        static void Replace(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
                if (FalseWords.ContainsKey(str[i].ToLower()))
                    str[i] = FalseWords[str[i].ToLower()];
        }

        static void RegexReplace(ref string str)
        {
            string rep = "+380 12 345 67 89";
            Regex regex = new Regex(@"[(](\d{3})[)] (\d{3})-(\d{2})-(\d{2})");
            str = regex.Replace(str, rep);
        }

        static string[] GetText()
        {
            using (StreamReader sr = new StreamReader(FileName))
                return sr.ReadToEnd().Split(' ');
        }

        static void OutText(string str)
        {
            File.Delete(FileName);
            File.WriteAllText(FileName, str);
        }

        static string ArrToStr(string[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
                str += arr[i] + " ";
            return str;
        }

        static void Main(string[] args)
        {
            string[] temp = GetText();
            Replace(temp);
            string res = ArrToStr(temp);
            RegexReplace(ref res);
            OutText(res);
            Console.ReadKey();
        }
    }
}
