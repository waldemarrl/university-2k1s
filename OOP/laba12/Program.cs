using System;

namespace laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LVDDiskInfo.FreeSpace();
                /*6. Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о
        действиях пользователя за определенный день/ диапазон времени/по
        ключевому слову. Посчитайте количество записей в нем. Удалите часть
        информации, оставьте только записи за текущий час.
        */
                DateTime startTime = new(2021, 11, 11, 11, 11, 11);
                DateTime endTime = new(2022, 11, 11, 11, 11, 11);
                LVDDirInfo.GetDirInf("C:\\");
                Type type = endTime.GetType();
                Console.WriteLine($"--------{type}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
