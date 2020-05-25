using System;
namespace a1 {
    partial class Program {
        static void DisplayMovies() {
            int size = _library.Size();
            int.TryParse(Math.Ceiling(size/2.0).ToString(), out int pages);
            int currentPage = 1;
            DisplayMovies:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===============Display all movies===============");
            MovieCollection currentMovies = _library.Subcollection(((currentPage-1)*2), ((currentPage)*2));
            currentMovies.Display();
            Console.Write("\n    Page: 0 (Return)");
            for(int i = 1; i <= pages; i++) {
                if(i == currentPage) {
                    Console.Write(" [{0}]", i.ToString());
                } else {
                    Console.Write("  {0} ", i.ToString());
                }
            }
            Console.WriteLine("\n================================================");
            ConsoleKeyInfo c = Console.ReadKey(true);
            if(c.Key == ConsoleKey.Escape) return;
            if(c.KeyChar.ToString()=="0") return;
            int.TryParse(c.KeyChar.ToString(), out int v);
            if(v > 0 && v <= pages) currentPage = v < 0 ? 0 : v > pages ? pages : v;
            goto DisplayMovies;
        }
        static void Borrow() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===============Borrow a movie DVD===============");
            Console.WriteLine("   Which movie would you like to borrow?\n");
            Console.WriteLine("   Or press 'Escape' to exit");
            Console.WriteLine("================================================");
            Console.Write(" Title: ");
            ConsoleKeyInfo key = Console.ReadKey();
            string title = "";
            if(key.Key == ConsoleKey.Escape) {
                return;
            } else {
                title += key.KeyChar.ToString();
            }
            title += Console.ReadLine();
            Movie movie = _library.Find(title);
            if(movie == null) {
                Console.WriteLine("\n   Could not find movie {0}", title);
                Console.ReadKey(true);
                Borrow();
                return;
            } else if(_current.Movies.Find(movie.Title) != null && _current.Movies.Find(movie.Title).Title == title) {
                Console.WriteLine("\n   You are already borrowing {0}", title);
                Console.ReadKey(true);
                Borrow();
                return;
            } else if(movie.Copies == 0) {
                Console.WriteLine("\n   {0} has no available copies remaining", title);
                Console.ReadKey(true);
                Borrow();
                return;
            }
            _current.Borrow(_library.Find(title));
            _library.Find(title).Borrow();
            Console.WriteLine("\n   Successfully borrowed {0}", title);
            Console.ReadKey(true);
            Borrow();
        }
        static void Return() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===============Return a movie DVD===============");
            Console.WriteLine("   Which movie would you like to borrow?\n");
            Console.WriteLine("   Or press 'Escape' to exit");
            Console.WriteLine("================================================");
            Console.Write(" Title: ");
            ConsoleKeyInfo key = Console.ReadKey();
            string title = "";
            if(key.Key == ConsoleKey.Escape) {
                return;
            } else {
                title += key.KeyChar.ToString();
            }
            title += Console.ReadLine();
            Movie movie = MemberCollection.GetMovies(_current).Find(title);
            if(movie == null) {
                Console.WriteLine("\n   You are not currently borrowing {0}", title);
                Console.ReadKey(true);
                Return();
                return;
            }
            _current.Return(MemberCollection.GetMovies(_current).Find(title));
            _library.Find(title).Return();
            Console.WriteLine("\n   Successfully returned {0}", title);
            Console.ReadKey(true);
            Return();
        }
        static void ListBorrowed() {
            int size = MemberCollection.GetMovies(_current).Size();
            int.TryParse(Math.Ceiling(size/2.0).ToString(), out int pages);
            int currentPage = 1;
            DisplayMyMovies:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("========List current borrowed movie DVDs========");
            MovieCollection currentMovies = MemberCollection.GetMovies(_current).Subcollection((currentPage-1)*2, (currentPage)*2);
            currentMovies.Display();
            Console.Write("\n    Page: 0 (Return)");
            for(int i = 1; i <= pages; i++) {
                if(i == currentPage) {
                    Console.Write(" [{0}]", i.ToString());
                } else {
                    Console.Write("  {0} ", i.ToString());
                }
            }
            Console.WriteLine("\n================================================");
            ConsoleKeyInfo c = Console.ReadKey(true);
            if(c.Key == ConsoleKey.Escape) return;
            if(c.KeyChar.ToString()=="0") return;
            int.TryParse(c.KeyChar.ToString(), out int v);
            if(v > 0 && v <= pages) currentPage = v < 0 ? 0 : v > pages ? pages : v;
            goto DisplayMyMovies;
        }
        static void TopTen() {
            int size = _library.Size();
            if(size > 10) size = 10;
            int.TryParse(Math.Ceiling(size/5.0).ToString(), out int pages);
            int currentPage = 1;
            DisplayTopTen:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("=======Display top 10 most popular movies=======");
            MovieCollection top = _library.Subcollection(0, size, "top");
            top = top.Subcollection((currentPage-1)*5, (currentPage)*5, "top");
            top.Display(currentPage);
            Console.Write("\n    Page: 0 (Return)");
            for(int i = 1; i <= pages; i++) {
                if(i == currentPage) {
                    Console.Write(" [{0}]", i.ToString());
                } else {
                    Console.Write("  {0} ", i.ToString());
                }
            }
            Console.WriteLine("\n================================================");
            ConsoleKeyInfo c = Console.ReadKey(true);
            if(c.Key == ConsoleKey.Escape) return;
            if(c.KeyChar.ToString()=="0") return;
            int.TryParse(c.KeyChar.ToString(), out int v);
            if(v > 0 && v <= pages) currentPage = v < 0 ? 0 : v > pages ? pages : v;
            goto DisplayTopTen;
        }
    }
}
