using System;
using FileSorter.BL.Controller;


namespace FileSorter.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке, в которой нужно выполнить сортировку.");
            Console.Write("Путь: ");
            string path = Console.ReadLine();
            FileSorterController controller = new FileSorterController(path);
            Console.WriteLine("Старт сортировки.");
            controller.Sort();
            Console.WriteLine("Сортировка выполнена.");
            Console.ReadLine();
        }
    }
}
