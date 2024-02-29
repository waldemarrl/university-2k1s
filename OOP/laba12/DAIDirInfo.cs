using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    static class LVDDirInfo
    {
        public static void GetDirInf(string path)
        {
            DirectoryInfo dir = new(path);
            Console.WriteLine($"Directory name: {dir.Name}");
            Console.WriteLine($"Directory creation time: {dir.CreationTime}");
            Console.WriteLine($"Directory parent: {dir.Parent}");
            Console.WriteLine($"Directory root: {dir.Root}");
            Console.WriteLine($"Directory subdirectories: {dir.GetDirectories().Length}");
            Console.WriteLine($"Directory files: {dir.GetFiles().Length}\n\n");
            DAILog.WriteToFile(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
    }
}
