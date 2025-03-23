namespace Seminar4_HW
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int[] nums = { 1, 4, 2, 7, 3, 9, 5 };
            int target = 10;

            List<int> result = FindThreeSum(nums, target);

            if (result != null)
            {
                Console.WriteLine($"Найдены числа: {result[0]}, {result[1]}, {result[2]}");
            }
            else
            {
                Console.WriteLine("Такие числа не найдены.");
            }
        }

        static List<int> FindThreeSum(int[] nums, int target)
        {
            // Сортируем массив для удобства поиска
            Array.Sort(nums);

            // Используем List для хранения результата
            List<int> result = new List<int>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int firstNumber = nums[i];
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = firstNumber + nums[left] + nums[right];

                    if (sum == target)
                    {
                        // Нашли тройку чисел
                        result.Add(firstNumber);
                        result.Add(nums[left]);
                        result.Add(nums[right]);
                        return result;
                    }
                    else if (sum < target)
                    {
                        // Увеличиваем сумму, сдвигая левый указатель вправо
                        left++;
                    }
                    else
                    {
                        // Уменьшаем сумму, сдвигая правый указатель влево
                        right--;
                    }
                }
            }

            // Если ничего не найдено
            return null;
        }
    }
}
