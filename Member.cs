namespace a1 {
    public class Member {
        public string FirstName {get; set;}
        public string Surname {get; set;}
        public string Address {get; set;}
        public string Phone {get; set;}
        private string Password;
        public MovieCollection Movies {get; set;}
        public Member(string firstName, string surname, string address, string phone, string password, MovieCollection movies) {
            FirstName = firstName;
            Surname = surname;
            Address = address;
            Phone = phone;
            Password = password;
            Movies = movies;
        }
        public void Borrow(Movie movie) {
            Movies.Add(movie);
        }
        public void Return(Movie movie) {
            Movies.Delete(movie.Title);
        }
        public bool Login(string password) {
            return password == Password;
        }
        public static string firstUpper(string s) {
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public static string getFullName(string name) {
            string[] names = name.Split(" ");
            string temp = firstUpper(names[0]);
            for(int i = 0; i < names.Length-1; i++) {
                names[i] = firstUpper(names[i+1]);
            }
            names[names.Length-1] = temp;
            return string.Join("", names);
        }
    }
}