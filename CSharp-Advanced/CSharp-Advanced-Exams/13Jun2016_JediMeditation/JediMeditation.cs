using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13Jun2016_P01.JediMeditation
{
    public class JediMeditation
    {
        public static void Main()
        {
            var jediQueue = new Queue<string>();
            int lines = int.Parse(Console.ReadLine());
            bool isYodaPresent = false;

            var masters = new StringBuilder();
            var knights = new StringBuilder();
            var slavToshko = new StringBuilder();
            var padawans = new StringBuilder();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    string currentJedi = input[j];

                    switch (currentJedi[0])
                    {
                        case 'm':
                            masters.Append($"{currentJedi} ");
                            break;
                        case 'k':
                            knights.Append($"{currentJedi} ");
                            break;
                        case 'p':
                            padawans.Append($"{currentJedi} ");
                            break;
                        case 's':
                            slavToshko.Append($"{currentJedi} ");
                            break;
                        case 't':
                            slavToshko.Append($"{currentJedi} ");
                            break;
                        case 'y':
                            isYodaPresent = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            var finalQueue = new StringBuilder();

            if (isYodaPresent)
            {
                finalQueue.Append(masters);
                finalQueue.Append(knights);
                finalQueue.Append(slavToshko);
                finalQueue.Append(padawans);

                Console.WriteLine(finalQueue.ToString().TrimEnd());
            }
            else
            {
                finalQueue.Append(slavToshko);
                finalQueue.Append(masters);
                finalQueue.Append(knights);
                finalQueue.Append(padawans);

                Console.WriteLine(finalQueue.ToString().TrimEnd());
            }
        }
    }
}