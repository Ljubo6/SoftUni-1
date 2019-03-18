using System;
using System.IO;

namespace P04.Copy_Binary_File
{
    class BinaryFile
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream(@"..\..\..\..\Resources\copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream(@"copiedFile.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];

                        int bufferSize = reader.Read(buffer, 0, buffer.Length);

                        if (bufferSize == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, bufferSize);
                    }
                }
            }
        }
    }
}
