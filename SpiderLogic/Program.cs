using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("\t\t The Master Mind Game");
            Console.WriteLine("\t\t ====================");
            int[] codeMaker = GetIntArray(random.Next(10000));
            List<string> output = new List<string>();
            Console.WriteLine("\n\t Code maker is ready with his 4 digit numeric code.\n");
            Console.Write("\n\t Please enter your guess and press enter :- ");
            string userInput = Console.ReadLine();
            try
            {
                if (userInput.Length == codeMaker.Count())
                {
                    int[] codeBreaker = GetIntArray(Convert.ToInt32(userInput));
                    for(int i = 0; i< codeMaker.Count(); i++)
                    {
                        if(codeBreaker.ElementAt(i) == codeMaker.ElementAt(i))
                        {
                            output.Add("BULL");
                        }
                        else if(codeMaker.Contains(codeBreaker.ElementAt(i)))
                        {
                            output.Add("COW");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(output.Where(value => value == "BULL").Count() > 0 ? "\n\t " + output.Where(value => value == "BULL").Count() + " BULL AND " : "\n\t NO BULL AND ");
                    Console.WriteLine(output.Where(value => value == "COW").Count()> 0 ? output.Where(value => value == "COW").Count() + " COW":"NO COW");
                    Console.ResetColor();

                    Console.WriteLine("\n\t Codemaker code was :- "+ string.Join("", codeMaker));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t Please enter only "+ codeMaker.Count() + " digit number.");
                    Console.ResetColor();
                }

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t Please enter valid number.");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\n\t Press any key to exit the application.");
                Console.ReadLine();
            }
        }
        static int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
    }
}
