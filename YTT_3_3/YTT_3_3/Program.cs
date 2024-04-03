// УП Практическая работа 1.3
// Задание 3. Дан файл, содержащий несколько целых чисел количеством i.
// Создайте массив height длиной i.
// Каждый элемент массива это вертикальная линия определенной длины.
// Найдите две линии, которые вместе с осью x образуют контейнер, содержащий наибольшее количество воды

namespace YTT_3_3
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string path = "input.txt";
            Console.Write("Введите количество чисел: ");
            int countNum = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[countNum];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 15);
            }
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i + 1 == array.Length)
                    {
                        await writer.WriteAsync(Convert.ToString($"{array[i]}"));
                    }
                    else
                    {
                        await writer.WriteAsync(Convert.ToString($"{array[i]} "));
                    }
                    
                }
            }

            List<int> height = new List<int>();
            using (StreamReader reader = new StreamReader(path))
            {
                string[] nums = (await reader.ReadToEndAsync()).Split(' ');
                for (int i = 0; i < nums.Length; i++)
                { 
                    height.Add(Convert.ToInt32(nums[i]));
                }
            }

            int max = 0, line1 = 0, line2 = 0, num = 0;
            for (int i = 0; i < height.Count; i++)
            {
                for (int j = i + 1; j < height.Count; j++)
                {
                    if (height[i] > height[j])
                    {
                        num = height[j];
                    }
                    else if (height[j] > height[i])
                    {
                        num = height[i];
                    }
                    else if (height[i] == height[j])
                    {
                        num = height[i];
                    }
                    if (num * (j - i) > max)
                    {
                        max = num * (j - i);
                        line1 = height[i];
                        line2 = height[j];
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteAsync(Convert.ToString($"\n{max}"));
                Console.WriteLine($"Наибольшее количество воды: {max}");
                Console.WriteLine($"Линия 1: {line1}");
                Console.WriteLine($"Линия 2: {line2}");
            }
            
        }
    }
}