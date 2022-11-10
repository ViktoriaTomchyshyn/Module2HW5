using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5
{
    public class FileService
    {
        private string _currentFilePath;
        public FileService()
        {
            DeleteOldFiles();
            CreateFile();
        }

        public void WriteToFile(string logs)
        {
            File.WriteAllText(_currentFilePath, logs);
        }

        private void DeleteOldFiles()
        {
            // deleting old files and creating new one
            if (!System.IO.Directory.Exists(ConfigService.GetLogsPath()))
            {
                System.IO.Directory.CreateDirectory(ConfigService.GetLogsPath());
            }

            string currentDirName = ConfigService.GetLogsPath();
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");
            FileInfo[] fileInfo = new FileInfo[files.Length];

            if (files != null && files.Length > 2)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    System.IO.FileInfo fi = null;
                    try
                    {
                        fi = new System.IO.FileInfo(files[i]);
                        fileInfo[i] = fi;
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                Array.Sort(fileInfo, (x, y) => Comparer<DateTime>.Default.Compare(y.CreationTime, x.CreationTime));

                for (int i = 0; i < fileInfo.Length; i++)
                {
                    try
                    {
                        if (i >= 2)
                        {
                            fileInfo[i].Delete();
                        }
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
            }
        }

        private void CreateFile()
        {
            string fileName = DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".txt";
            string pathString = ConfigService.GetLogsPath();

            pathString = System.IO.Path.Combine(pathString, fileName);
            _currentFilePath = pathString;

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
        }
    }
}
