using System;
namespace a1 {
    public class MovieNode {
        public Movie Movie {get; set;}
        public MovieNode Left {get; set;}
        public MovieNode Right {get; set;}
        public MovieNode(Movie m) {
            Movie = m;
            Left = null;
            Right = null;
        }
    }
}