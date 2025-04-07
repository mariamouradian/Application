using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Seminar8_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Использование: utility.exe <расширение> <текст> [<директория>]");
                Console.WriteLine("Пример: utility.exe txt \"искомый текст\"");
                Console.WriteLine("Поиск по текущей директории: utility.exe cs \"public class\"");
                return;
            }

            string extension = args[0].StartsWith(".") ? args[0] : "." + args[0];
            string searchText = args[1];
            string searchDirectory = args.Length > 2 ? args[2] : Directory.GetCurrentDirectory();

            try
            {
                Console.WriteLine($"Поиск файлов {extension}, содержащих текст: \"{searchText}\"");
                Console.WriteLine($"Директория: {searchDirectory}\n");

                var foundFiles = SearchFilesRecursive(searchDirectory, extension, searchText);

                Console.WriteLine("\nРезультаты поиска:");
                if (foundFiles.Count == 0)
                {
                    Console.WriteLine("Файлы не найдены");
                }
                else
                {
                    Console.WriteLine($"Найдено файлов: {foundFiles.Count}");
                    foreach (var file in foundFiles)
                    {
                        Console.WriteLine(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static List<string> SearchFilesRecursive(string directory, string extension, string searchText)
        {
            var result = new List<string>();

            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Директория не существует: {directory}");
                return result;
            }

            try
            {
                // Поиск файлов с нужным расширением
                foreach (string filePath in Directory.GetFiles(directory, "*" + extension))
                {
                    try
                    {
                        // Чтение содержимого файла и проверка на наличие текста (без учета регистра)
                        string content = File.ReadAllText(filePath);
                        if (content.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            result.Add(filePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка чтения файла {filePath}: {ex.Message}");
                    }
                }

                // Рекурсивный поиск в поддиректориях
                foreach (string subDir in Directory.GetDirectories(directory))
                {
                    try
                    {
                        result.AddRange(SearchFilesRecursive(subDir, extension, searchText));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка доступа к директории {subDir}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке директории {directory}: {ex.Message}");
            }

            return result;
        }
    }
}
