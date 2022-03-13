using System;
using System.IO;
using FileSorter.BL.Controller;


namespace FileSorter.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите путь к папке, в которой нужно выполнить сортировку.");
            //Console.Write("Путь: ");
            //string path = Console.ReadLine();
            //FileSorterController controller = new FileSorterController(path);
            //Console.WriteLine("Старт сортировки.");
            //controller.Sort();
            //Console.WriteLine("Сортировка выполнена.");
            //C:\\testFoleSorter\\AfterSort\\15.05.2021\\20210515_152328.jpg

            //FileInfo file = new FileInfo("C:\\testFoleSorter\\AfterSort\\15.05.2021\\20210515_152328.jpg");
            //Console.Write("Полный путь: ");
            //Console.WriteLine(file.FullName);
            //Console.Write("Имя файла: ");
            //Console.WriteLine(file.Name);
            //Console.Write("Расширение файла: ");
            //Console.WriteLine(file.Extension);
            //Console.Write("Расположение директории: ");
            //Console.WriteLine(file.DirectoryName);
            //Console.WriteLine(file.ToString());
            Sorter sorter = new Sorter("C:\\testFoleSorter");
            sorter.Execute();
            Console.ReadLine();
        }
    }
}
