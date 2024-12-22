using System;

namespace AdvancedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Приветственное сообщение для пользователя
            Console.WriteLine("Добро пожаловать в многофункциональный калькулятор!");
            Console.WriteLine("Введите 'exit' для выхода из программы.");

            // Бесконечный цикл для продолжения работы калькулятора
            while (true)
            {
                try
                {
                    // Запрашиваем у пользователя первое число
                    Console.Write("Введите первое число: ");
                    string input1 = Console.ReadLine();
                    // Проверяем, не ввел ли пользователь команду выхода
                    if (input1.ToLower() == "exit") break;

                    // Преобразуем введенное значение в число
                    double number1 = Convert.ToDouble(input1);

                    // Запрашиваем у пользователя операцию
                    Console.Write("Введите операцию (+, -, *, /, ^, sqrt, sin, cos, tan, asin, acos, atan, cotan, acotan): ");
                    string operation = Console.ReadLine();

                    double result = 0; // Переменная для хранения результата вычисления

                    // Проверяем, если операция - извлечение квадратного корня
                    if (operation == "sqrt")
                    {
                        result = SquareRoot(number1); // Вызываем метод для извлечения квадратного корня
                    }
                    else
                    {
                        // Запрашиваем у пользователя второе число для операций с двумя числами
                        Console.Write("Введите второе число: ");
                        string input2 = Console.ReadLine();
                        double number2 = Convert.ToDouble(input2); // Преобразуем второе значение в число

                        // Вызываем метод для выполнения операции и получаем результат
                        result = PerformOperation(number1, number2, operation);
                    }

                    // Выводим результат на экран
                    Console.WriteLine($"Результат: {result}");
                }
                catch (FormatException)
                {
                    // Обрабатываем ошибку формата ввода (например, если введено не число)
                    Console.WriteLine("Ошибка: неверный формат числа. Пожалуйста, попробуйте снова.");
                }
                catch (DivideByZeroException)
                {
                    // Обрабатываем ошибку деления на ноль
                    Console.WriteLine("Ошибка: деление на ноль невозможно.");
                }
                catch (Exception ex)
                {
                    // Обрабатываем любые другие исключения и выводим сообщение об ошибке
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Выполняет арифметическую операцию между двумя числами.
        /// </summary>
        /// <param name="number1">Первое число.</param>
        /// <param name="number2">Второе число.</param>
        /// <param name="operation">Операция.</param>
        /// <returns>Результат операции.</returns>
        private static double PerformOperation(double number1, double number2, string operation)
        {
            switch (operation) // Проверяем тип операции
            {
                case "+":
                    return number1 + number2; // Сложение
                case "-":
                    return number1 - number2; // Вычитание
                case "*":
                    return number1 * number2; // Умножение
                case "/":
                    if (number2 == 0) throw new DivideByZeroException(); // Проверка деления на ноль
                    return number1 / number2; // Деление
                case "^":
                    return Math.Pow(number1, number2); // Возведение в степень
                case "sin":
                    return Math.Sin(number1); // Синус
                case "cos":
                    return Math.Cos(number1); // Косинус
                case "tan":
                    return Math.Tan(number1); // Тангенс
                case "asin":
                    return Math.Asin(number1); // Арксинус
                case "acos":
                    return Math.Acos(number1); // Арккосинус
                case "atan":
                    return Math.Atan(number1); // Арктангенс
                case "cotan":
                    return 1 / Math.Tan(number1); // Котангенс (обратная функция тангенса)
                case "acotan":
                    return Math.PI / 2 - Math.Atan(number1); // Арккотангенс (обратная функция котангенса)
                default:
                    throw new InvalidOperationException("Неизвестная операция."); // Обработка неизвестной операции
            }
        }

        /// <summary>
        /// Извлекает квадратный корень из числа.
        /// </summary>
        /// <param name="number">Число.</param>
        /// <returns>Квадратный корень.</returns>
        private static double SquareRoot(double number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException("Число должно быть неотрицательным."); // Проверка на отрицательное число
            return Math.Sqrt(number); // Извлечение квадратного корня из числа
        }
    }
}
