using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P05.Directory_Traversal
{
    class FilesInDirectory
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            var filesExtension = new Dictionary<string, List<FileInfo>>();

            for (int i = 0; i < allFiles.Length; i++)
            {
                var currentFileInfo = new FileInfo(allFiles[i]);

                string extentsion = currentFileInfo.Extension;

                if (!filesExtension.ContainsKey(extentsion))
                {
                    filesExtension.Add(extentsion, new List<FileInfo> { currentFileInfo });
                }
                else
                {
                    filesExtension[extentsion].Add(currentFileInfo);
                }
            }

            filesExtension = filesExtension.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            string desktopUniversalPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var writer = new StreamWriter($"{desktopUniversalPath}\\report.txt", true))
            {
                foreach (var extension in filesExtension)
                {
                    writer.WriteLine($"{extension.Key}");
                    foreach (var file in extension.Value.OrderBy(x=>x.Length))
                    {
                        writer.WriteLine($"--{file.Name} - {(double)file.Length/1024:f3}kb");
                    }
                }
            }
        }
    }
}
