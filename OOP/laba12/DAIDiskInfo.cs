using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba12
{
    static class LVDDiskInfo
    {
        public static void FreeSpace()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Drive name: {drive.Name}");
                Console.WriteLine($"Drive size: {drive.TotalSize}");
                Console.WriteLine($"Drive free space: {drive.TotalFreeSpace}");
                Console.WriteLine($"Drive label: {drive.VolumeLabel}\n\n");
            }
            DAILog.WriteToFile(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
    }
}
