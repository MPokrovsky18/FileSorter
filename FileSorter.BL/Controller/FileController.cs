using System;
using System.IO;

namespace FileSorter.BL.Controller
{
    internal class FileController
    {
        private FileInfo _file;

        public string currentFileName => _file.Name;
        public DateTime LastFileWriteTime => _file.LastWriteTime;
        public DateTime CreationFileTime => _file.CreationTime;
        public string FileExtension => _file.Extension;

        public void AddFileToController(string path)
        {
            try
            {
                if (path == null)
                {
                    throw new ArgumentNullException("Путь к файлу не может быть NULL.", nameof(path));
                }

                if (File.Exists(path))
                {
                    _file = new FileInfo(path);
                }
                else
                {
                    string messageException = $"Путь к файлу: {path} - не найден";
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

        public void FileMove(string pathTargetDirectory)
        {
            try
            {
                if (pathTargetDirectory == null)
                {
                    throw new ArgumentNullException("Путь к директории не может быть NULL.", nameof(pathTargetDirectory));
                }

                if (Directory.Exists(pathTargetDirectory))
                {
                    _file?.MoveTo(pathTargetDirectory + "\\" + currentFileName);
                }
                else
                {
                    string messageException = $"Путь к директории: {pathTargetDirectory} - не найден";
                    throw new ArgumentException(messageException, nameof(pathTargetDirectory));
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
    }
}
