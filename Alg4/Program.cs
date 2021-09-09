using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Alg4
{
    class Program
    {
        public static HashSet<string> hashSet = new HashSet<string>();

        public static string[] myArray = new string[10000];
        public static void CreateWord(HashSet<string> H, string[] A )
        {
            int num_letters = 10000;
            int num_words = 5;
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Random rand = new Random();

            for (int i = 0; i < num_words; i++)
            {

                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {

                    int letter_num = rand.Next(0, letters.Length - 1);


                    word += letters[letter_num];
                }

                
                H.Add(word);
                A[i] = word;
            }

        }
        static void Main(string[] args)
        {
            
            CreateWord(hashSet, myArray);
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

//      результат замера производительности получился в соответствии с ожидаемым: в хеш-таблице поиск значительно быстрее

//            | Method | Mean | Error | StdDev |
//| ---------------- | --------------:| ------------:| ------------:|
//    | TestHashSearch | 1.503 ns | 0.0174 ns | 0.0154 ns |
//| TestArraySearch | 20,355.846 ns | 163.8059 ns | 136.7854 ns |


        }
    }

    public class BenchmarkClass
    {
        string S = "ABCDE";

        [Benchmark]
        public void TestHashSearch()
        {
            Program.hashSet.Contains(S);
            
        }

        [Benchmark]
        public void TestArraySearch()
        {

            for (int i = 0; i< Program.myArray.Length; i++)
            {
                if (Program.myArray[i] == S)
                    return;
            }
        }

    }
}
