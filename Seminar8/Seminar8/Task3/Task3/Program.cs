namespace Task3
{
    internal class Program
    {
        const string path = "Program.cs";

        const string word = "List";
        
        static void Main(string[] args)
        {
            Console.WriteLine(word);
            var text = ReadFrom(path);
            var filter = Filter(word, text);
            Console.WriteLine(String.Join("\n", filter));
        }

        static List<string> ReadFrom(string path)
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    result.Add(line);
                }
            }
            return result;
        }

        static List<string> Filter (string word, List<string> text)
        {
            return text.Where(a => a.ToLower().Contains(word.ToLower())).Select(x => x.ToLower().Replace(word.ToLower(), word.ToUpper())).ToList();
        }
    }
}
