using System;
using System.Globalization;
namespace a1 {
    partial class Program {
        static void AddDVD() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the movie's title\n");
            Console.WriteLine("   Or press 'Escape' to exit");
            Console.WriteLine("================================================\n");
            Console.Write(" Title: ");
            ConsoleKeyInfo key = Console.ReadKey();
            string title = "";
            if(key.Key == ConsoleKey.Escape) {
                return;
            } else {
                title += key.KeyChar.ToString();
            }
            title += Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the movie's starring actors");
            Console.WriteLine("   Separate each star with a comma (,)");
            Console.WriteLine("================================================\n");
            Console.Write(" Stars: ");
            string[] parsedStarring = Console.ReadLine().Split(',');
            for(int i = 0; i < parsedStarring.Length; i++) {
                parsedStarring[i] = parsedStarring[i].TrimStart();
            }
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the movie's director");
            Console.WriteLine("================================================\n");
            Console.Write(" Director: ");
            string director = Console.ReadLine();
            Runtime:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the movie's runtime");
            Console.WriteLine("   Please give your response in minutes");
            Console.WriteLine("================================================\n");
            Console.Write(" Duration: ");
            if(!int.TryParse(Console.ReadLine(), out int parsedDuration)) {
                Console.WriteLine("\n   Not a valid amount of time");
                Console.ReadKey(true);
                goto Runtime;
            }
            Genre:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the movie's genre");
            Console.WriteLine("   Choose between: Drama, Adventure,");
            Console.WriteLine("   Family, Action, Sci-Fi, Comedy,");
            Console.WriteLine("   Animated, Thriller or Other");
            Console.WriteLine("================================================\n");
            Console.Write(" Genre: ");
            string g = Console.ReadLine();
            if(g == "Sci-Fi") g = "SciFi";
            if(!Enum.TryParse(g, out Genre parsedGenre)) {
                Console.WriteLine("\n   Not a valid genre");
                Console.ReadKey(true);
                goto Genre;
            }
            Classification:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the movie's classification");
            Console.WriteLine("   Choose: G (General)");
            Console.WriteLine("           PG (Parental Guidance)");
            Console.WriteLine("           M (Mature)");
            Console.WriteLine("           MA (Mature Accompanied)");
            Console.WriteLine("================================================\n");
            Console.Write(" Classification: ");
            if(!Enum.TryParse(Console.ReadLine(), out Classification parsedClassification)) {
                Console.WriteLine("\n   Not a valid Classification");
                Console.ReadKey(true);
                goto Classification;
            }
            ReleaseDate:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the release date");
            Console.WriteLine("================================================\n");
            Console.Write(" Release Date: ");
            if(!DateTime.TryParse(Console.ReadLine(), out DateTime parsedReleaseDate)) {
                Console.WriteLine("\n   Not a valid Date");
                Console.ReadKey(true);
                goto ReleaseDate;
            }
            Copies:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Please enter the amount of DVDs you");
            Console.WriteLine("   would like to add");
            Console.WriteLine("================================================\n");
            Console.Write(" Copies: ");
            if(!int.TryParse(Console.ReadLine(), out int parsedCopies)) {
                Console.WriteLine("\n   Not a valid amount of copies");
                Console.ReadKey(true);
                goto Copies;
            }
            Final:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Add a new movie DVD===============");
            Console.WriteLine("   Do you want to add this movie?\n");
            Console.WriteLine("   {0, -15} {1, 29}", "Title:", title);
            Console.WriteLine("   {0, -15} {1, 29}", "Stars:", MovieCollection.Truncate(string.Join(", ", parsedStarring)));
            Console.WriteLine("   {0, -15} {1, 29}", "Director:", director);
            Console.WriteLine("   {0, -15} {1, 29}", "Duration:", parsedDuration.ToString() + " minutes");
            Console.WriteLine("   {0, -15} {1, 29}", "Genre:", parsedGenre.ToString());
            Console.WriteLine("   {0, -15} {1, 29}", "Classification:", parsedClassification.ToString());
            Console.WriteLine("   {0, -15} {1, 29}", "Release Date:", parsedReleaseDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
            Console.WriteLine("   {0, -15} {1, 29}", "Copies:", parsedCopies.ToString());
            Console.WriteLine("================================================\n");
            Console.Write(" yes/no: ");
            string res = Console.ReadLine();
            switch(res) {
                case("yes"):
                case("Yes"):
                case("y"):
                case("Y"):
                    AddDVD(title, parsedStarring, director, parsedDuration, parsedGenre, parsedClassification, parsedReleaseDate, parsedCopies);
                    Console.WriteLine("\n   Successfully added {0} to the library", title);
                    Console.ReadKey(true);
                    break;
                case("no"):
                case("No"):
                case("n"):
                case("N"):
                    break;
                default:
                    goto Final;
            }
        }
        static void AddDVD(string title, string[] starring, string director, int duration, Genre genre, Classification classification, DateTime releaseDate, int copies) {
            _library.Add(new Movie(title, starring, director, duration, genre, classification, releaseDate, copies));
        }
        static void RemoveDVD() {
            RemoveStart:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===============Remove a movie DVD===============");
            Console.WriteLine("   Please enter the title of the movie");
            Console.WriteLine("   you wish to remove\n");
            Console.WriteLine("   Or press 'Escape' to exit");
            Console.WriteLine("================================================\n");
            Console.Write(" Title: ");
            ConsoleKeyInfo key = Console.ReadKey();
            string title = "";
            if(key.Key == ConsoleKey.Escape) {
                return;
            } else {
                title += key.KeyChar.ToString();
            }
            title += Console.ReadLine();
            if(_library.Find(title) == null) {
                Console.WriteLine("\n   Could not find movie {0}", title);
                Console.ReadKey(true);
                goto RemoveStart;
            }
            Movie toBeRemoved = _library.Find(title);
            RemoveConfirm:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===============Remove a movie DVD===============");
            Console.WriteLine("   Do you want to remove this movie?\n");
            Console.WriteLine("   {0, -15} {1, 29}", "Title:", toBeRemoved.Title);
            Console.WriteLine("   {0, -15} {1, 29}", "Stars:", MovieCollection.Truncate(string.Join(", ", toBeRemoved.Starring)));
            Console.WriteLine("   {0, -15} {1, 29}", "Director:", toBeRemoved.Director);
            Console.WriteLine("   {0, -15} {1, 29}", "Duration:", toBeRemoved.Duration.ToString() + " minutes");
            Console.WriteLine("   {0, -15} {1, 29}", "Genre:", toBeRemoved.Genre.ToString());
            Console.WriteLine("   {0, -15} {1, 29}", "Classification:", toBeRemoved.Classification.ToString());
            Console.WriteLine("   {0, -15} {1, 29}", "Release Date:", toBeRemoved.ReleaseDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
            Console.WriteLine("   {0, -15} {1, 29}", "Copies:", toBeRemoved.Copies.ToString());
            Console.WriteLine("================================================\n");
            Console.Write(" yes/no: ");
            string res = Console.ReadLine();
            switch(res) {
                case("yes"):
                case("Yes"):
                case("y"):
                case("Y"):
                    RemoveDVD(title);
                    Console.WriteLine("\n   Successfully removed {0} from the library", title);
                    Console.ReadKey(true);
                    break;
                case("no"):
                case("No"):
                case("n"):
                case("N"):
                    break;
                default:
                    goto RemoveConfirm;
            }
        }
        static void RemoveDVD(string title) {
            _library.Delete(title);
        }
        static void RegisterMember() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("=============Register a new Member==============");
            Console.WriteLine("   Please enter the member's first name\n");
            Console.WriteLine("   Or press 'Escape' to exit");
            Console.WriteLine("================================================\n");
            Console.Write(" First Name: ");
            ConsoleKeyInfo key = Console.ReadKey();
            string fName = "";
            if(key.Key == ConsoleKey.Escape) {
                return;
            } else {
                fName += key.KeyChar.ToString();
            }
            fName += Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("=============Register a new Member==============");
            Console.WriteLine("   Please enter the member's surname");
            Console.WriteLine("================================================\n");
            Console.Write(" Surname: ");
            string surname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("=============Register a new Member==============");
            Console.WriteLine("   Please enter the member's address");
            Console.WriteLine("================================================\n");
            Console.Write(" Address: ");
            string address = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===========Register a new Member============");
            Console.WriteLine("   Please enter the member's phone number");
            Console.WriteLine("================================================\n");
            Console.Write(" Phone: ");
            string phone = Console.ReadLine();
            SetupPassword:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("=============Register a new Member==============");
            Console.WriteLine("   Please enter the member's password");
            Console.WriteLine("================================================\n");
            Console.Write(" Password: ");
            string password = SilentPassword();
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("=============Register a new Member==============");
            Console.WriteLine("   Please enter the member's password again");
            Console.WriteLine("================================================\n");
            Console.Write(" Confirm Password: ");
            string passwordC = SilentPassword();
            if(password != passwordC) {
                Console.Write("\n   Passwords did not match");
                Console.ReadKey(true);
                goto SetupPassword;
            }
            FinalMember:
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("=============Register a new Member==============");
            Console.WriteLine("   Do you want to register this member?\n");
            Console.WriteLine("   {0, -15} {1, 29}", "Full Name:", fName + " " + surname);
            Console.WriteLine("   {0, -15} {1, 29}", "Username:", Member.getFullName(fName + " " + surname));
            Console.WriteLine("   {0, -15} {1, 29}", "Address:", address);
            Console.WriteLine("   {0, -15} {1, 29}", "Phone:", phone);
            Console.WriteLine("================================================\n");
            Console.Write(" yes/no: ");
            string res = Console.ReadLine();
            switch(res) {
                case("yes"):
                case("Yes"):
                case("y"):
                case("Y"):
                    _members.Add(new Member(fName, surname, address, phone, password, new MovieCollection()));
                    Console.WriteLine("\n   Successfully registered {0} {1}", fName, surname);
                    Console.ReadKey(true);
                    break;
                case("no"):
                case("No"):
                case("n"):
                case("N"):
                    break;
                default:
                    goto FinalMember;
            }
        }
        static void FindPhone() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==============Find a Phone number===============");
            Console.WriteLine("   Please enter the full name of the Member");
            Console.WriteLine("   whose phone number you want to find\n");
            Console.WriteLine("   For Example:");
            Console.WriteLine("                'John Smith'\n");
            Console.WriteLine("   Or press 'Escape' to exit");
            Console.WriteLine("================================================\n");
            Console.Write(" Full Name: ");
            ConsoleKeyInfo key = Console.ReadKey();
            string name = "";
            if(key.Key == ConsoleKey.Escape) {
                return;
            } else {
                name += key.KeyChar.ToString();
            }
            name += Console.ReadLine();
            string fullname = Member.getFullName(name);
            if(!_members.Contains(fullname)) {
                Console.WriteLine("\n   Could not find member '{0}'", name);
                Console.ReadKey(true);
                FindPhone();
            } else {
                Console.WriteLine("\n {0}'s phone number is: {1}", name, _members.Find(fullname).Phone);
                Console.ReadKey(true);
                FindPhone();
            }
        }
    }
}