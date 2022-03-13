using System;
using System.IO;


namespace FileSorter.BL.Controller
{
    public class Sorter
    {
        private DirectoryInfo _originDirectory;
        private DirectoryInfo _destinationDirectory;

        public Sorter(string pathOriginDirectory)
        {
            AddOriginDirectory(pathOriginDirectory);
            _destinationDirectory = new DirectoryInfo(Path.Combine(_originDirectory.FullName, "AfterSort"));
        }

        private void AddOriginDirectory(string path)
        {
            try
            {
                if (path == null)
                {
                    throw new ArgumentNullException("Путь к директории не может быть NULL.", nameof(path));
                }

                if (Directory.Exists(path))
                {
                    _originDirectory = new DirectoryInfo(path);
                }
                else
                {
                    string messageException = $"Путь к директории: {path} - не найден";
                    throw new ArgumentException(messageException, nameof(path));
                }
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void Execute()
        {
            DirectoryController origin = new DirectoryController(_originDirectory.FullName);
            origin.CreateSubDirectory(_destinationDirectory.Name);
            Console.WriteLine($"Оригинальный каталог: {_originDirectory}");

            ShowFiles(origin);

            foreach (DirectoryInfo d in origin.GetSubdirectory(_destinationDirectory))
            {
                ShowFiles(new DirectoryController(d.FullName));
            }
        }

        private void ShowFiles(DirectoryController dir)
        {
            Console.WriteLine($"Каталог - {dir.Name}");

            foreach (string f in dir)
            {
                Console.WriteLine(f);
            }
        }
    }
}
