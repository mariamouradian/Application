/*Напишите утилиту рекурсивного поиска файлов в заданном каталоге и подкаталогах*/


namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Использование: Программа <путь_к_папке> <строка_для_поиска>");
                return; // Завершаем программу, если аргументов недостаточно
            }

            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            List<string> list = SearchIn(path: args[0], name: args[1]);
            Console.WriteLine(string.Join("\n", list));
        }


        private static List<string> SearchIn(string path, string name)
        {
            var list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                var directories = dir.GetDirectories();
                var files = dir.GetFiles();

                foreach (var item in files)
                {
                    if (item.Name.Contains(name))
                    {
                        list.Add(item.Name); 
                    }

                    if (item.Extension.Contains(name))
                    {
                        list.Add(item.Name);
                    }
                }

                foreach (var item in directories)
                {
                    list.AddRange(SearchIn(item.FullName, name)); // Исправлено: передаем name, а не item.Name
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Пропускаем каталоги, к которым нет доступа
            }

            return list;
        }

    }
}

