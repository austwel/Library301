using System;

namespace a1 {
    public class Movie {
        public string Title {get;}
        public string[] Starring {get;}
        public string Director {get;}
        public int Duration {get;}
        public Genre Genre {get;}
        public Classification Classification {get;}
        public DateTime ReleaseDate {get;}
        public int Borrowed {get;set;}
        public int Copies {get;set;}
        public Movie(string title, string[] starring, string director, int duration, Genre genre, Classification classification, DateTime releaseDate, int copies) {
            Title = title;
            Starring = starring;
            Director = director;
            Duration = duration;
            Genre = genre;
            Classification = classification;
            ReleaseDate = releaseDate;
            Borrowed = 0;
            Copies = copies;
        }
        public void Borrow() {
            Borrowed++;
            Copies--;
        }
        public void Return() {
            Copies++;
        }
    }
}