// УП Практическая работа 1.3
// Задание 1. На различных мероприятиях команда стажировок регулярно разыгрывает призы в лотерею.
// Организаторы выбирают 10 случайных различных чисел от 1 до 32.
// Каждому участнику выдается лотерейный билет, на котором записаны 6 различных чисел от 1 до 32.
// Билет считается выигрышным, если в нем есть не менее 3 выбранных организаторами числа.
// Помогите Юле, напишите программу, которая будет сообщать, какие билеты выигрышные.

namespace YTT_3_1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string inputPath = "input.txt";
            string outputPath = "output.txt";

            using (StreamWriter writer = new StreamWriter(inputPath, false))
            {
                Console.Write("Организатор, введите 10 случайных чисел: ");
                await writer.WriteLineAsync(Console.ReadLine());
                Console.Write("Организатор, введите количество билетов: ");
                string countTicket = Console.ReadLine();
                await writer.WriteLineAsync(countTicket);
                if (Convert.ToInt32(countTicket) >= 1 & Convert.ToInt32(countTicket) <= 1000)
                {
                    for (int i = 0; i < Convert.ToInt32(countTicket); i++)
                    {
                        Console.Write("Участник, введите числа записанные на лотерейном билете: ");
                        await writer.WriteLineAsync(Console.ReadLine());
                    }
                }
            }

            using (StreamReader reader = new StreamReader(inputPath))
            {
                void error()
                {
                    Console.WriteLine("Ошибка при вводе данных!");
                    return;
                }

                string line1 = await reader.ReadLineAsync();
                string[] randomNumsStr = line1.Split(' ');
                int[] randomNumsInt = new int[10];

                if (randomNumsStr.Length != 10)
                {
                    error();
                    return;
                }

                for (int i = 0; i < randomNumsStr.Length; i++)
                {
                    if (Convert.ToInt32(randomNumsStr[i]) < 1 || Convert.ToInt32(randomNumsStr[i]) > 32)
                    {
                        error();
                        return;
                    }

                    if (!int.TryParse(randomNumsStr[i], out randomNumsInt[i]))
                    {
                        error();
                        return;
                    }
                }

                string line2 = await reader.ReadLineAsync();
                for (int i = 0; i < Convert.ToInt32(line2); i++)
                {
                    string lineTicket = await reader.ReadLineAsync();
                    string[] ticketStr = lineTicket.Split(' ');

                    if (ticketStr.Length != 6)
                    {
                        error();
                        continue;
                    }

                    int[] ticketInt = new int[6];

                    for (int j = 0; j < ticketStr.Length; j++)
                    {
                        if (Convert.ToInt32(ticketStr[j]) < 1 || Convert.ToInt32(ticketStr[j]) > 32)
                        {
                            error();
                            return;
                        }

                        if (!int.TryParse(ticketStr[j], out ticketInt[j]))
                        {
                            error();
                            return;
                        }
                    }

                    int countLuck = 0;
                    for (int j = 0; j < randomNumsInt.Length; j++)
                    {
                        for (int k = 0; k < ticketInt.Length; k++)
                        {
                            if (ticketInt[k] == randomNumsInt[j])
                            {
                                countLuck++;
                            }
                        }
                    }

                    if (countLuck >= 3)
                    {
                        Console.WriteLine("Lucky");
                        using (StreamWriter writer = new StreamWriter(outputPath, true))
                        {
                            await writer.WriteLineAsync("Lucky");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unlucky");
                        using (StreamWriter writer = new StreamWriter(outputPath, true))
                        {
                            await writer.WriteLineAsync("Unlucky");
                        }
                    }
                }
            }
        }
    }
}