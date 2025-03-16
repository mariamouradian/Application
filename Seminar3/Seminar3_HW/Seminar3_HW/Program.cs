namespace Seminar3_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
            };

            int startI = 1; // Начальная точка (строка)
            int startJ = 1; // Начальная точка (столбец)

            int exitCount = HasExit(startI, startJ, labirynth1);
            Console.WriteLine($"Количество выходов: {exitCount}");
        }

        static int HasExit(int startI, int startJ, int[,] l)
        {
            int rows = l.GetLength(0);
            int cols = l.GetLength(1);

            // Проверка, что начальная точка находится в пределах лабиринта
            if (startI < 0 || startI >= rows || startJ < 0 || startJ >= cols)
                return 0;

            // Если начальная точка — стена, выходов нет
            if (l[startI, startJ] == 1)
                return 0;

            // Создаем копию лабиринта, чтобы не изменять оригинальный
            int[,] visited = (int[,])l.Clone();

            // Рекурсивный поиск выходов
            return DFS(startI, startJ, visited);
        }

        static int DFS(int i, int j, int[,] visited)
        {
            int rows = visited.GetLength(0);
            int cols = visited.GetLength(1);

            // Проверка, что текущая клетка находится в пределах лабиринта
            if (i < 0 || i >= rows || j < 0 || j >= cols)
                return 0;

            // Если клетка — стена или уже посещена, пропускаем
            if (visited[i, j] == 1)
                return 0;

            // Если клетка — выход (на границе лабиринта и равна 0), увеличиваем счетчик
            int exitCount = 0;
            if ((i == 0 || i == rows - 1 || j == 0 || j == cols - 1) && visited[i, j] == 0)
            {
                exitCount = 1;
            }

            // Помечаем клетку как посещенную
            visited[i, j] = 1;

            // Рекурсивно проверяем соседние клетки
            exitCount += DFS(i + 1, j, visited); // Вниз
            exitCount += DFS(i - 1, j, visited); // Вверх
            exitCount += DFS(i, j + 1, visited); // Вправо
            exitCount += DFS(i, j - 1, visited); // Влево

            return exitCount;
        }
    }
}
