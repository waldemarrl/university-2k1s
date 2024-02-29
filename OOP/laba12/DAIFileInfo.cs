
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    static class LVDFileInfo
    {
        public static void GetFileInfo(string path)
        {
            FileInfo file = new(path);
            Console.WriteLine($"Full path: {file.FullName}");
            Console.WriteLine($"File size: {file.Length}");
            Console.WriteLine($"File extension: {file.Extension}");
            Console.WriteLine($"File name: {file.Name}");
            Console.WriteLine($"File creation time: {file.CreationTime}");
            Console.WriteLine($"File last access time: {file.LastAccessTime}");
            Console.WriteLine($"File last write time: {file.LastWriteTime}\n\n");
            DAILog.WriteToFile(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
    }
}
