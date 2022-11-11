do
{
    int count = System.IO.File.ReadAllLines("d:\\Matrica.txt").Length;
    FileStream file = new FileStream("d:\\Matrica.txt", FileMode.OpenOrCreate);
    StreamReader reader = new StreamReader(file);
    StreamWriter writer = new StreamWriter(file);


    FileStream fileGlav = new FileStream("d:\\Glav.txt", FileMode.OpenOrCreate);
    StreamReader readerGlav = new StreamReader(fileGlav);
    StreamWriter writerGlav = new StreamWriter(fileGlav);

    FileStream filePob = new FileStream("d:\\Pob.txt", FileMode.OpenOrCreate);
    StreamReader readerPob = new StreamReader(filePob);
    StreamWriter writerPob = new StreamWriter(filePob);

    Random rnd = new Random();

    int sum = 0;

    Console.WriteLine("1 - Новая генерация\n2 - Старая генерация");
    if (!int.TryParse(Console.ReadLine(), out int gen) || gen > 2 || gen < 1)
    {
        Console.WriteLine("\nОшибка! не-то что-то ввели");
    }

    switch (gen)
    {
        case 1:
            {
                file.SetLength(0);
                Console.WriteLine("\nУкажите размер матрицы: ");
                if (!int.TryParse(Console.ReadLine(), out int arraySize))
                {
                    Console.WriteLine("\nОшибка! не-то что-то ввели");
                }
                int[,] array = new int[arraySize, arraySize];
                string[] array2 = new string[arraySize];

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = rnd.Next(-10, 10);
                        writer.Write(array[i, j] + " ");
                    }
                    writer.WriteLine();
                }

                Console.WriteLine("\n1 - Главная\n2 - Побочная");
                if (!int.TryParse(Console.ReadLine(), out int poisc) || poisc > 2 || poisc < 1)
                {
                    Console.WriteLine("\nОшибка! не-то что-то ввели");
                    return;
                }
                switch (poisc)
                {
                    case 1:
                        {
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    if (i == j)
                                    {
                                        writerGlav.Write($"{array[i, j]} - Элемент главной диагонали");
                                        writerGlav.WriteLine();
                                        sum += array[i, j];
                                    }
                                }
                            }
                            writerGlav.WriteLine($"\nСумма Главной: {sum}");
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    if (j == array.GetLength(0) - i - 1)
                                    {
                                        writerPob.Write($"{array[i, j]} - Элемент побочной диагонали");
                                        writerPob.WriteLine();
                                        sum += array[i, j];
                                    }
                                }
                            }
                            writerPob.WriteLine($"\nСумма побочной: {sum}");
                            break;
                        }
                }
                break;
            }
        case 2:
            {
                int[,] array = new int[count, count];
                string arrayLines;

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    arrayLines = reader.ReadLine();
                    string[] array2 = arrayLines.Split(" ");
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = Convert.ToInt32(array2[j]);
                    }
                }

                Console.WriteLine("\n1 - Главная\n2 - Побочная");
                if (!int.TryParse(Console.ReadLine(), out int poisc) || poisc > 2 || poisc < 1)
                {
                    Console.WriteLine("\nОшибка! не-то что-то ввели");
                    return;
                }
                switch (poisc)
                {
                    case 1:
                        {
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    if (i == j)
                                    {
                                        writerGlav.Write($"{array[i, j]} - Элемент главной диагонали");
                                        writerGlav.WriteLine();
                                        sum += array[i, j];
                                    }
                                }
                            }
                            writerGlav.WriteLine($"\nСумма Главной: {sum}");
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    if (j == array.GetLength(0) - i - 1)
                                    {
                                        writerGlav.Write($"{array[i, j]} - Элемент побочной диагонали");
                                        writerGlav.WriteLine();
                                        sum += array[i, j];
                                    }
                                }
                            }
                            writerPob.WriteLine($"\nСумма побочной: {sum}");
                            break;
                        }
                }
                break;
            }
    }

    writerGlav.Close();
    writerPob.Close();
    readerPob.Close();
    readerGlav.Close();
    writer.Close();
    reader.Close();

    Console.WriteLine("\nЗапуск - ENTER;\nВыход из программы - ESC");
} while (Console.ReadKey().Key != ConsoleKey.Escape);
