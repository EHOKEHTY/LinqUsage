using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;

namespace LinqUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new List<object>() {
                "Hello",
                new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                new List<int>() {4, 6, 8, 2},
                new string[] {"Hello inside array"},
                new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                    new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                    "Leonardo DiCaprio"
                };
            Console.WriteLine("1. Виведіть усі елементи, крім ArtObjects");
            Console.WriteLine(string.Join(Environment.NewLine, data.Where(x => x  is not ArtObject)));

            Console.WriteLine("2. Виведіть імена всіх акторів");
            Console.WriteLine(string.Join(Environment.NewLine, data.OfType<Film>().SelectMany(f => f.Actors.Select(a => a.Name))));

            Console.WriteLine("3. Виведіть кількість акторів, які народилися в серпні");
            Console.WriteLine(data.OfType<Film>().SelectMany(f => f.Actors).Count(a => a.Birthdate.Month == 8));

            Console.WriteLine("4. Виведіть два найстаріших імена акторів");
            Console.WriteLine(string.Join(Environment.NewLine, data.OfType<Film>().SelectMany(f => f.Actors).OrderByDescending(a => a.Birthdate).Take(2).Select(a => a.Name)));

            Console.WriteLine("5. Вивести кількість книг на авторів");
            Console.WriteLine(data.OfType<Book>().GroupBy(b => b.Author).Count());

            Console.WriteLine("6. Виведіть кількість книг на одного автора та фільмів на одного режисера");
            Console.WriteLine(data.OfType<Book>().Count() / (double)data.OfType<Film>().Select(f => f.Author).Distinct().Count());

            Console.WriteLine("7. Виведіть, скільки різних букв використано в іменах усіх акторів");
            Console.WriteLine(data.OfType<Film>().SelectMany(f => f.Actors).SelectMany(a => a.Name).Distinct().Count());

            Console.WriteLine("8. Виведіть назви всіх книг, упорядковані за іменами авторів і кількістю сторінок");
            Console.WriteLine(string.Join(Environment.NewLine, data.OfType<Book>().OrderBy(b => b.Author).ThenBy(b => b.Pages).Select(b => b.Name)));

            Console.WriteLine("9. Виведіть ім'я актора та всі фільми за участю цього актора");
            Console.WriteLine(string.Join(Environment.NewLine, data.OfType<Film>().SelectMany(f => f.Actors.Select(a => $"{a.Name}: {f.Name}"))));

            Console.WriteLine("10. Виведіть суму загальної кількості сторінок у всіх книгах і всі значення int у всіх послідовностях у даних");
            Console.WriteLine(data.OfType<Book>().Sum(b => b.Pages) + data.OfType<IEnumerable<int>>().SelectMany(x => x).Sum());

            Console.WriteLine("11. Отримати словник з ключем - автор книги, значенням - список авторських книг");
            var authorBooksDictionary = data.OfType<Book>().GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.ToList());
            Console.WriteLine(string.Join(Environment.NewLine, authorBooksDictionary.Select(kv => $"{kv.Key}: {string.Join(", ", kv.Value.Select(b => b.Name))}")));

            Console.WriteLine("12. Вивести всі фільми \"Метт Деймон\", за винятком фільмів з акторами, імена яких представлені в даних у вигляді рядків");
            Console.WriteLine(string.Join(Environment.NewLine, data.OfType<Film>().Where(f => f.Actors.All(a => !data.Contains(a.Name)) && f.Actors.Any(a => a.Name == "Matt Damon")).Select(f => f.Name)));

        }

        class Actor
        {
            public string Name { get; set; }
            public DateTime Birthdate { get; set; }
        }

        abstract class ArtObject
        {
            public string Author { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
        }

        class Film : ArtObject
        {
            public int Length { get; set; }
            public IEnumerable<Actor> Actors { get; set; }
        }

        class Book : ArtObject
        {
            public int Pages { get; set; }
        }

    }
}

