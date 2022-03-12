using System;
using System.Collections.Generic;
using System.IO;


namespace FileSorter.BL.Controller
{
    public class FileSorterController
    {
        private string _pathOriginDirectory;
        private string[] _files;
        private string _afterSortDirectionName = "AfterSort";

        public FileSorterController(string pathOriginDirectory)
        {
            if (string.IsNullOrWhiteSpace(pathOriginDirectory))
            {
                throw new ArgumentNullException("Путь к директории не может быть пустым или NULL.", nameof(pathOriginDirectory));
            }

            if (Directory.Exists(pathOriginDirectory))
            {
                _pathOriginDirectory = pathOriginDirectory;
            }
            else
            {
                throw new ArgumentException("Путь к директории не найден.");
            }

            _files = GetFilesFromDirectory(_pathOriginDirectory);

            Directory.CreateDirectory(_pathOriginDirectory + "\\" + _afterSortDirectionName);

        }

        private string[] GetFilesFromDirectory(string path)
        {
            List<string> files = new List<string>(Directory.GetFiles(path));
            string[] directories = Directory.GetDirectories(path);

            foreach (string directory in directories)
            {
                string[] newFiles = GetFilesFromDirectory(directory);

                if (newFiles != null)
                {
                    files.AddRange(newFiles);
                }
            }

            if (files.Count > 0)
            {
                return files.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < _files.Length; i++)
            {
                string targetFile = _files[i];
                string fileName = Path.GetFileName(targetFile);
                string targetDirectory = GetDateFileCreation(targetFile);
                string newPath = _pathOriginDirectory + "\\" + _afterSortDirectionName + "\\" + targetDirectory;

                if (Directory.Exists(newPath) == false)
                {
                    Directory.CreateDirectory(newPath);
                }

                File.Move(targetFile, newPath + "\\" + fileName);
            }
        }

        private string GetDateFileCreation(string filePath)
        {
            DateTime dateCreation = File.GetCreationTime(filePath);
            DateTime dateLastWrite = File.GetLastWriteTime(filePath);

            if (dateCreation < dateLastWrite)
            {
                return dateCreation.ToShortDateString().ToString();
            }
            else
            {
                return dateLastWrite.ToShortDateString().ToString();
            }
        }
    }
}
