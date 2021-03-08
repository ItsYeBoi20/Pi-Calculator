using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pi_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pi Calculator by ItsYeBoi  | Status: Idle";
            string CalculatePi(int digits)
            {
                digits++;

                uint[] x = new uint[digits * 10 / 3 + 2];
                uint[] r = new uint[digits * 10 / 3 + 2];

                uint[] pi = new uint[digits];

                for (int j = 0; j < x.Length; j++)
                    x[j] = 20;

                for (int i = 0; i < digits; i++)
                {
                    uint carry = 0;
                    for (int j = 0; j < x.Length; j++)
                    {
                        uint num = (uint)(x.Length - j - 1);
                        uint dem = num * 2 + 1;

                        x[j] += carry;

                        uint q = x[j] / dem;
                        r[j] = x[j] % dem;

                        carry = q * num;
                    }


                    pi[i] = (x[x.Length - 1] / 10);


                    r[x.Length - 1] = x[x.Length - 1] % 10; ;

                    for (int j = 0; j < x.Length; j++)
                        x[j] = r[j] * 10;
                }

                var result = "";

                uint c = 0;

                for (int i = pi.Length - 1; i >= 0; i--)
                {
                    pi[i] += c;
                    c = pi[i] / 10;

                    result = (pi[i] % 10).ToString() + result;
                }

                string test = result.Insert(1, ",");

                return test;
            }
        beginning:

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pi Calculator by ItsYeBoi2016");
            Console.WriteLine("How Many digits do you want to calculate?");
            Console.ResetColor();

            string readline = Console.ReadLine();
            int n;
            var isNumeric = int.TryParse(readline, out n);
            if (isNumeric == true)
            {
                Console.Clear();

                Console.Title = "Pi Calculator by ItsYeBoi  | Status: Running";
                Console.WriteLine(CalculatePi(n));
                Console.Title = "Pi Calculator by ItsYeBoi  | Status: Idle";

                Console.ReadKey();
                while(true)
                {
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("You didnt enter a valid Number!");
                Thread.Sleep(1000);
                Console.Clear();
                goto beginning;
            }
        }
    }
}
