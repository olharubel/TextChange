using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Nature <is <an important<
 and integral> part> 
of mankind>*/

namespace TextChange
{
    class Program
    {

        static StringBuilder[] ToStringBuilder(string[] text)
        {
            StringBuilder[] result = new StringBuilder[text.Length];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = new StringBuilder(text[i]);
            }
            return result;
        }

        static string[] StringBuilderToString(StringBuilder[] text)
        {
            string[] result = new string[text.Length];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = text[i].ToString();
            }
            return result;
        }


        static string[] ReplaceSymbols(string[] text)
        {


            List<KeyValuePair<int, int>> indexes = new List<KeyValuePair<int, int>>();       //key - index of string, value - index of symbol
            for (int i = 0; i < text.Length; ++i)
            {
                for (int j = 0; j < text[i].Length; ++j)
                {
                    if (text[i][j] == '#')
                    {
                        indexes.Add(new KeyValuePair<int, int>(i, j));
                    }
                }
            }

            StringBuilder[] sb = ToStringBuilder(text);

            if (indexes.Count % 2 != 0)
            {
                throw new Exception("Not even numbers of '#");
            }

            for (int i = 0; i < indexes.Count / 2; ++i)
            {
                sb[indexes[i].Key][indexes[i].Value] = '<';
                sb[indexes[indexes.Count - i - 1].Key][indexes[indexes.Count - i - 1].Value] = '>';
            }

            return StringBuilderToString(sb);
        }


        static void Main(string[] args)
        {
            try
            {
                string[] textLines = FileWorker.ReadFromFile(@"C:\Users\Ростик\source\repos\TextChange\Text.txt");
                var text = ReplaceSymbols(textLines);

                foreach (var line in text)
                {
                    Console.WriteLine(line);
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadLine();

        }
    }
}
