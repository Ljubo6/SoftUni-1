using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BitCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxCodesGenerated = int.Parse(Console.ReadLine());
            int totalCount = 0;
            string result = "";


            for (int M = 33; M <= 47; M++)
            {
                if (M > 47) { M = 33; }
                for (int N = 58; N <= 64; N++)
                {
                    if (N > 64) { N = 58; }
                    for (int x = 1; x <= a; x++)
                    {
                        for (int y = 1; y <= b; y++)
                        {
                            totalCount++;

                            if (totalCount <= maxCodesGenerated)
                            {

                                Console.Write((char)M + "" + (char)N + "" + x + "" + y + "" + (char)N + "" + (char)M);
                                Console.Write('|');
                                
                            }
                            y++;
                            
                        }
                        x++;
                        
                    }
                    N++;
                    
                }
                M++;
            }

        }

    }
}

