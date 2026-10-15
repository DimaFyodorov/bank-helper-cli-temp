namespace BankHelperCLI;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Банковское приложение: Расчет вклада ===");

        Console.Write("Введите сумму вклада: ");
        decimal principal = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("""
Выберите срок вклада (введите номер варианта):
1 — 91 день  (11.50%)
2 — 181 день (11.75%)
3 — 365 дней (12.50%)
""");

        Console.Write("Ваш выбор: ");

        (int days, decimal rate) = Console.ReadLine() switch
        {
            "1" => (91, 0.1150m),
            "2" => (181, 0.1175m),
            "3" => (365, 0.1250m),
            _ => (0, 0m)
        };

        if (days == 0 || principal <= 0)
        {
            Console.WriteLine("\n[Ошибка] Неверно выбран вариант срока или введена некорректная сумма.");
            return;
        }

        decimal interest = principal * rate * days / 365m;
        decimal finalAmount = principal + interest;

        string resultMessage = $"""
================ Результаты ================
Сумма первоначального взноса: {principal:F2}
Срок вклада:                  {days} дней
Годовая ставка:               {rate * 100:F2}%
Начисленные проценты:         {interest:F2}
Итоговая сумма в конце срока: {finalAmount:F2}
============================================
""";

        Console.WriteLine(resultMessage);
    }
}
