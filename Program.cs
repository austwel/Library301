using System;
namespace a1 {
    partial class Program {
        //Global variables
        public static MovieCollection _library; //Collection of movies in the library
        public static MemberCollection _members; //Collection of member users
        public static MemberCollection _staff; //Collection of staff users
        public static Member _current; //Stores user that is currently logged in, staff or member
        //Main process
        //Input: string[] args
        //Output: None
        static void Main(string[] args) {
            _library = DummyMovies();
            _members = DummyMembers();
            _staff = StaffList();
            MainMenu();
        }
        //Creates list of staff as given in the task outline
        //Input: None
        //Output: MemberCollection staff (user: staff, pass: today123)
        static MemberCollection StaffList() {
            MemberCollection staffList = new MemberCollection();
            staffList.Add(new Member("staff", "", "", "", "today123", new MovieCollection()));
            return staffList;
        }
        //Console application home menu and portal hub
        //Input: Menu selection
        //Output: Redirect to given login page
        static void MainMenu() {
            Console.Clear();
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("===================Main Menu====================");
            Console.WriteLine("   1. Staff Login");
            Console.WriteLine("   2. Member Login");
            Console.WriteLine("   0. Exit");
            Console.WriteLine("================================================\n");
            Console.Write(" Please make a selection (1-2, or 0 to exit): ");
            ConsoleKeyInfo res = Console.ReadKey(true);
            switch(res.KeyChar) {
                case('0'):
                    System.Environment.Exit(0);
                    break;
                case('1'):
                    StaffLogin();
                    break;
                case('2'):
                    MemberLogin();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
        //Login attempt for a member user
        //Input: string username and string password
        //Output: _current = user if successful
        static void MemberLogin() {
            Console.Clear();
            Console.WriteLine("\n==================Member Login==================");
            Console.WriteLine("   Please enter your username");
            Console.WriteLine("================================================\n");
            Console.Write(" Username: ");
            string username = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n==================Member Login==================");
            Console.WriteLine("   Please enter your password");
            Console.WriteLine("================================================\n");
            Console.Write(" Password: ");
            string password = SilentPassword();
            if(_members.Login(username, password)) {
                _current = _members.Find(username);
                MemberMenu();
            } else {
                Console.WriteLine("\n   Incorrect credentials");
                Console.ReadKey();
                MainMenu();
            }
        }
        //Home menu for member accounts
        //Input: Menu selection
        //Output: Redirect to member action
        static void MemberMenu() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("==================Member Menu===================");
            Console.WriteLine("   1. Display all movies");
            Console.WriteLine("   2. Borrow a movie DVD");
            Console.WriteLine("   3. Return a movie DVD");
            Console.WriteLine("   4. List current borrowed movie DVDs");
            Console.WriteLine("   5. Display top 10 most popular movies");
            Console.WriteLine("   0. Return to main menu");
            Console.WriteLine("================================================\n");
            Console.Write(" Please make a selection (1-5, or 0 to return to main menu): ");
            ConsoleKeyInfo res = Console.ReadKey(true);
            switch(res.KeyChar) {
                case('0'):
                    MainMenu();
                    break;
                case('1'):
                    DisplayMovies();
                    MemberMenu();
                    break;
                case('2'):
                    Borrow();
                    MemberMenu();
                    break;
                case('3'):
                    Return();
                    MemberMenu();
                    break;
                case('4'):
                    ListBorrowed();
                    MemberMenu();
                    break;
                case('5'):
                    TopTen();
                    MemberMenu();
                    break;
                default:
                    MemberMenu();
                    break;
            }
        }
        //Login attempt for a staff user
        //Input: string username and string password
        //Output: _current = user if successful
        static void StaffLogin() {
            Console.Clear();
            Console.WriteLine("\n==================Staff Login===================");
            Console.WriteLine("   Please enter your username");
            Console.WriteLine("================================================\n");
            Console.Write(" Username: ");
            string username = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n==================Staff Login===================");
            Console.WriteLine("   Please enter your password");
            Console.WriteLine("================================================\n");
            Console.Write(" Password: ");
            string password = SilentPassword();
            if(_staff.Login(username, password)) {
                _current = _staff.Find(username);
                StaffMenu();
            } else {
                Console.WriteLine("\n   Incorrect credentials");
                Console.ReadKey();
                MainMenu();
            }
        }
        //Staff home menu
        //Input: Menu selection
        //Output: Redirect to staff action
        static void StaffMenu() {
            Console.Clear();
            Console.WriteLine("Logged in as {0} {1}", _current.FirstName, _current.Surname);
            Console.WriteLine("===================Staff Menu===================");
            Console.WriteLine("   1. Add a new movie DVD");
            Console.WriteLine("   2. Remove a movie DVD");
            Console.WriteLine("   3. Register a new Member");
            Console.WriteLine("   4. Find a registered member's phone number");
            Console.WriteLine("   0. Return to main menu");
            Console.WriteLine("================================================\n");
            Console.Write(" Please make a selection (1-4, or 0 to return to main menu): ");
            ConsoleKeyInfo res = Console.ReadKey(true);
            switch(res.KeyChar) {
                case('0'):
                    MainMenu();
                    break;
                case('1'):
                    AddDVD();
                    StaffMenu();
                    break;
                case('2'):
                    RemoveDVD();
                    StaffMenu();
                    break;
                case('3'):
                    RegisterMember();
                    StaffMenu();
                    break;
                case('4'):
                    FindPhone();
                    StaffMenu();
                    break;
                default:
                    StaffMenu();
                    break;
            }
        }
        //Helper function to hide passwords while the user types them
        //Input: None
        //Output: string password
        static string SilentPassword() {
            string password = null;
            for(;;) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Enter) {
                    return password;
                }
                password += key.KeyChar;
            }
        }
    }
}
