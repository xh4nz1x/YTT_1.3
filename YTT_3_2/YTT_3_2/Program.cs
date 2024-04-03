// УП Практическая работа 1.3
// Задание 2. Дан файл(nums.txt), содержащий целые числа, через пробел.
// Удалите из него все четные числа.


namespace YTT_3_2
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string path = "nums.txt";
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                Console.Write("Введите целые числа: ");
                await writer.WriteLineAsync(Console.ReadLine());
            }
            List<string> arrayStr2 = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = await reader.ReadLineAsync();
                string[] arrayStr1 = line.Split(' ');
                
                for (int i = 0; i < arrayStr1.Length; i++)
                {
                    if (Convert.ToInt32(arrayStr1[i]) % 2 != 0 & arrayStr1 != null)
                    {
                        arrayStr2.Add(arrayStr1[i]);
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                for (int i = 0; i < arrayStr2.Count; i++)
                {
                    await writer.WriteAsync($"{arrayStr2[i]} ");
                }
                Console.WriteLine("Удалены все четные числа!");
            }
        }
    }
}