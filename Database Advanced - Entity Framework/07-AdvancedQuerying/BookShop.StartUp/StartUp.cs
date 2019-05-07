namespace BookShop
{
    using BookShop.Data;
    using BookShop.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //var input = int.Parse(Console.ReadLine());
                //var input = Console.ReadLine();
                var output = Removebook(db);
                Console.WriteLine(output);
            }
        }

        //P16. Removebooks
        public static string Removebook(BookShopContext db)
        {
            int minCopies = 4200;

            var booksToRemove = db.Books.Where(b => b.Copies < minCopies).ToArray();

            db.Books.RemoveRange(booksToRemove);
            int booksRemovedCount = db.SaveChanges();
            return $"{booksRemovedCount} books were deleted";
        }

        //P15. Increase Prices
        public static void IncreasePrices(BookShopContext db)
        {
            var books = db.Books.Where(b => b.ReleaseDate.Value.Year < 2010);
            foreach (var book in books)
            {
                book.Price += 5;
            }

            db.SaveChanges();
        }

        //P14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext db)
        {
            var recentBooksByCategory = db.Categories
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks
                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                            .Take(3)
                            .Select(b => new
                            {
                                BookTitle = b.Book.Title,
                                ReleaseYear = b.Book.ReleaseDate.Value.Year
                            }).ToList(),
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var info = new StringBuilder();
            foreach (var category in recentBooksByCategory)
            {
                info.AppendLine($"--{category.Name}");
                foreach (var book in category.RecentBooks)
                {
                    info.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");
                }
            }
            return info.ToString().TrimEnd();
        }

        //P13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            var profitByCategory = db.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();

            var info = new StringBuilder();
            foreach (var category in profitByCategory)
            {
                info.AppendLine($"{category.Name} - ${category.Profit}");
            }
            return info.ToString().TrimEnd();
        }

        //P12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext db)
        {
            var copiesByAuthor = db.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(b => b.Copies),
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            var info = new StringBuilder();
            foreach (var author in copiesByAuthor)
            {
                info.AppendLine($"{author.FullName} - {author.Copies}");
            }
            return info.ToString().TrimEnd();
        }

        //P11. Count Books
        public static int CountBooks(BookShopContext db, int lengthCheck)
        {
            var count = db.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        //P10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            var booksByAuthor = db.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title, AuthorName = b.Author.FirstName + " " + b.Author.LastName })
                .ToArray();

            var info = new StringBuilder();
            foreach (var book in booksByAuthor)
            {
                info.AppendLine($"{book.Title} ({book.AuthorName})");
            }
            return info.ToString().TrimEnd();
        }

        //P09. Book Search
        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {
            var bookTitles = db.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            var result = string.Join(Environment.NewLine, bookTitles);
            return result;
        }

        //P08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext db, string input)
        {
            var authors = db.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToArray();

            var result = string.Join(Environment.NewLine, authors);
            return result;
        }

        //P07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext db, string date)
        {
            var latestReleaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var releasedBooksUntilDate = db.Books
                .Where(b => b.ReleaseDate < latestReleaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            var info = new StringBuilder();
            foreach (var book in releasedBooksUntilDate)
            {
                info.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }
            return info.ToString().TrimEnd();
        }

        //P06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext db, string input)
        {
            var categories = input.ToLower().Split(new[] { " ", "\t", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var booksByCategory = db.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t);

            var result = string.Join(Environment.NewLine, booksByCategory);
            return result;
        }

        //P05. Not Released In
        public static string GetBooksNotRealeasedIn(BookShopContext db, int year)
        {
            var notRealeasedBookTitles = db.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var result = string.Join(Environment.NewLine, notRealeasedBookTitles);
            return result;
        }

        //P04. Books by Price
        public static string GetBooksByPrice(BookShopContext db)
        {
            decimal minPrice = 40m;

            var booksByPrice = db.Books
                .Where(b => b.Price > minPrice)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            var info = new StringBuilder();
            foreach (var book in booksByPrice)
            {
                info.AppendLine($"{book.Title} - ${book.Price}");
            }
            return info.ToString().TrimEnd();
        }

        //P03. Golden Books
        public static string GetGoldenBooks(BookShopContext db)
        {
            int copiesCount = 5000;

            var goldenBooksTitles = db.Books
                .Where(b => b.Copies < copiesCount && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var result = string.Join(Environment.NewLine, goldenBooksTitles);
            return result;
        }

        //P02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {
            int restrictionValue = int.MinValue;

            switch (command.ToLower())
            {
                case "minor":
                    restrictionValue = 0;
                    break;
                case "teen":
                    restrictionValue = 1;
                    break;
                case "adult":
                    restrictionValue = 2;
                    break;
                default:
                    break;
            }

            var bookTitlesByAgeRestriction = db.Books
                .Where(b => (int)b.AgeRestriction == restrictionValue)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            var result = string.Join(Environment.NewLine, bookTitlesByAgeRestriction);
            return result;
        }
    }
}
