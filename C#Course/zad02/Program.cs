using C_Course.zad02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad02
{

    class Program
    {
        static void Main(string[] args)
        {

            //zad 2

            //Parliament p = new(100);
            //p.StartVoting("test");
            //for(int i = 0; i < 100; i++)
            //{
            //    p.Parliamentalists[i].Vote();
            //}
            //p.EndVoting();
            //p.ShowResults();

            //p.Parliamentalists[0].Vote();

            int parlamentaristsCount;

            while (true)
            {
                Console.WriteLine("Podaj liczbe parlamentarzystow");
                try
                {
                    parlamentaristsCount = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) { Console.WriteLine("Wprowadz poprawna liczbe"); }
            }

            Parliament p = new(parlamentaristsCount);

            Console.WriteLine("Parlament gotowy do obrad");

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                //p.Parliamentalists[0].Vote();
                if (input[0] == "POCZATEK")
                {
                    p.StartVoting(String.Join(" ", input[1..]));
                    for (int i = 0; i < parlamentaristsCount; i++)
                        p.Parliamentalists[i].Vote();
                }
                if (input[0] == "KONIEC")
                {
                    p.EndVoting();
                }
            }


        }
    }
}
