do
{
    FileStream file = new FileStream("d:\\Chislo10.txt", FileMode.OpenOrCreate);
    StreamReader reader = new StreamReader(file);
    StreamWriter writer = new StreamWriter(file);
    FileStream file8 = new FileStream("d:\\Chislo8.txt", FileMode.OpenOrCreate);
    StreamReader reader8 = new StreamReader(file8);
    StreamWriter writer8 = new StreamWriter(file8);
    FileStream file2 = new FileStream("d:\\Chislo2.txt", FileMode.OpenOrCreate);
    StreamReader reader2 = new StreamReader(file2);
    StreamWriter writer2 = new StreamWriter(file2);

    Random random = new Random();

    Console.WriteLine("1 - Новая генерация\n2 - Старая генерация");
    if (!int.TryParse(Console.ReadLine(), out int gen) || gen > 2 || gen < 1)
    {
        Console.WriteLine("\nОшибка! не-то что-то ввели");
    }

    switch (gen)
    {
        case 1:
            {
                int chislo = 0;

                Console.WriteLine("Введите длинну: ");
                if (!int.TryParse(Console.ReadLine(), out int decSize))
                {
                    Console.WriteLine("\nОшибка! не-то что-то ввели");
                }

                for (int i = 0; i < decSize; i++)
                {
                    int ch = random.Next(0,10);
                    writer.Write(ch);

                    if (chislo != 0) { Convert.ToString(chislo); chislo = int.Parse(chislo + ch.ToString()); }
                }
                writer8.Write(Convert.ToString(chislo, 8));
                writer2.Write(Convert.ToString(chislo, 2));


                break;
            }
        case 2:
            {
                int chislo = Convert.ToInt32(reader.ReadLine());
                writer8.Write(Convert.ToString(chislo, 8));
                writer2.Write(Convert.ToString(chislo, 2));
                break;
            }
    }
    writer.Close();
    reader.Close();
    writer2.Close();
    reader2.Close();
    writer8.Close();
    reader8.Close();
    Console.WriteLine("\nЗапуск - ENTER;\nВыход из программы - ESC");
} while (Console.ReadKey().Key != ConsoleKey.Escape) ;
