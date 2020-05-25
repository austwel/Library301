using System;
namespace a1 {
    //Part of main process which controls members' abilities
    partial class Program {
        //Displays movies in pages of 2, with information about each movie
        //Input: Page number selection or return
        //Output: Display movie data from that page
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
        //Borrow a movie from the library
        //Input: Movie title
        //Output: Movie added to the _current Member's personal MovieCollection, Movie's borrowed++, copies--
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
        //Return a movie to the library
        //Input: title of a movie currently borrowed by the _current Member
        //Output: Movie removed from _current Member's personal MovieCollection and Movie's copies++
        static void Return() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===============Return a movie DVD===============");
            Console.WriteLine("   Which movie would you like to return?\n");
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
        //Lists all movies and their information currently borrowed in the _current Member's name
        //Input: None
        //Output: Movie data for all movies in _current Member's personal MovieCollection
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
        //Returns information about the top ten most borrowed movies in the library
        //Input: None
        //Output: Outputs the movies in a ranking system from 1. to 10. based on the
        //        amount of times they have been borrowed
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
