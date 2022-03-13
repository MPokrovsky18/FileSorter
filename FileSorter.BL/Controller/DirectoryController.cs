using System;
using System.Collections;
using System.IO;

namespace FileSorter.BL.Controller
{
    internal class DirectoryController : IEnumerable
    {
        private DirectoryInfo _directory;

        public string Name => _directory.Name;

        public DirectoryController(string path)
        {
            AddDirectoryToController(path);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (FileInfo file in _directory.EnumerateFiles())
            {
                yield return file.ToString();
            }
        }

        public IEnumerable GetSubdirectory()
        {
            foreach (DirectoryInfo dir in _directory.EnumerateDirectories())
            {
                yield return dir;
            }
        }

        public IEnumerable GetSubdirectory(DirectoryInfo ignoreDirectory)
        {
            foreach (DirectoryInfo dir in _directory.EnumerateDirectories())
            {
                if (!ignoreDirectory.Name.Equals(dir.Name))
                {
                    yield return dir;
                }
            }
        }

        private void AddDirectoryToController(string path)
        {
            try
            {
                if (path == null)
                {
                    throw new ArgumentNullException("Путь к директории не может быть NULL.", nameof(path));
                }

                if (Directory.Exists(path))
                {
                    _directory = new DirectoryInfo(path);
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

        public void CreateSubDirectory(string nameSubdirectory)
        {
            string newDirectoryPath = Path.Combine(_directory.FullName, nameSubdirectory);

            if (Directory.Exists(newDirectoryPath) == false)
            {
                _directory.CreateSubdirectory(nameSubdirectory);
            }
        }

        public void DeleteDirectory()
        {
            try
            {
                _directory.Delete();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"{nameof(_directory)} - NULL");
            }
            catch (IOException)
            {
                Console.WriteLine($"Директория: {_directory.FullName} - имеет файлы. Удалить нельзя.");
            }
        }

    }
}
