using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;

namespace LinqUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Виведіть усі числа від 10 до 50 через кому");
            Console.Write("\t");
            Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41)));
            Console.Write("\n");

            Console.WriteLine("2. Виведіть лише ті числа від 10 до 50, які можна поділити на 3");
            Console.Write("\t");
            Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41).Where(item => item % 3 == 0)));
            Console.Write("\n");

            Console.WriteLine("3. Виведіть слово \"Linq\" 10 разів");
            Console.Write("\t");
            Console.WriteLine(string.Join(" ", Enumerable.Repeat("Linq", 10)));
            Console.Write("\n");

            Console.WriteLine("4. Вивести всі слова з буквою «а» в рядку «aaa;abb;ccc;dap»");
            Console.Write("\t");
            Console.WriteLine(string.Join("; ", "aaa;abb;ccc;dap".Split(';').Where(word => word.Contains('a'))));
            Console.Write("\n");

            Console.WriteLine("5. Виведіть кількість літер «а» у словах з цією літерою в рядку «aaa;abb;ccc;dap» через кому");
            Console.Write("\t");
            Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';').Select(word => word.Count(letter => letter == 'a'))));
            Console.Write("\n");

            Console.WriteLine("6. Вивести true, якщо слово \"abb\" існує в рядку \"aaa;xabbx;abb;ccc;dap\", інакше false");
            Console.Write("\t");
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Any(word => word == "abb"));
            Console.Write("\n");

            Console.WriteLine("7. Отримати найдовше слово в рядку \"aaa;xabbx;abb;ccc;dap\"");
            Console.Write("\t");
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').OrderByDescending(word => word.Length).First());
            Console.Write("\n");

            Console.WriteLine("8. Обчислити середню довжину слова в рядку \"aaa;xabbx;abb;ccc;dap\"");
            Console.Write("\t");
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Average(word => word.Length));
            Console.Write("\n");

            Console.WriteLine("9. Вивести найкоротше слово в рядку \"aaa;xabbx;abb;ccc;dap;zh\" у зворотному порядку.");
            Console.Write("\t");
            Console.WriteLine("aaa;xabbx;abb;ccc;dap;zh".Split(';').OrderBy(word => word.Length).First().Reverse().ToArray());
            Console.Write("\n");

            Console.WriteLine("10. Вивести true, якщо в першому слові, яке починається з \"aa\", усі літери \"b\" (За винятком \"аа\"), інакше false \"baaa;aabb;aaa;xabbx;abb;ccc;dap;zh\"");
            Console.Write("\t");
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').FirstOrDefault(word => word.StartsWith("aa") && word.Skip(2).All(letter => letter == 'b')) != null);
            Console.Write("\n");

            Console.WriteLine("11. Вивести останнє слово в послідовності, за винятком перших двох елементів, які закінчуються на \"bb\" (використовуйте послідовність із 10 завдання)");
            Console.Write("\t");
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').Reverse().Skip(2).FirstOrDefault(word => word.EndsWith("bb")));
            Console.Write("\n");
        }
    }
    }
}