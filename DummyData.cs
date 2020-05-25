using System;
namespace a1 {
    partial class Program {
        static MovieCollection DummyMovies() {
            MovieCollection dummyLibrary = new MovieCollection();
            dummyLibrary.Add(new Movie(
                "The Irishman", 
                new string[] { 
                    "Robert De Niro", 
                    "Al Pacino", 
                    "Joe Pesci", 
                }, 
                "Martin Scorsese", 
                209, 
                Genre.Thriller, 
                Classification.MA, 
                new DateTime(2019, 11, 27), 
                3
            ));
            dummyLibrary.Add(new Movie(
                "Once Upon a Time in Hollywood", 
                new string[] { 
                    "Leonardo DiCaprio",
                    "Brad Pitt",
                    "Margot Robbie" 
                }, 
                "Quentin Tarantino", 
                161, 
                Genre.Comedy, 
                Classification.MA, 
                new DateTime(2019, 8, 15), 
                2
            ));
            dummyLibrary.Add(new Movie(
                "Avengers: Endgame", 
                new string[] { 
                    "Robert Downey Jr.",
                    "Chris Evans",
                    "Mark Ruffalo"
                }, 
                "Anthony & Joe Russo", 
                181, 
                Genre.Adventure, 
                Classification.M, 
                new DateTime(2019, 4, 24), 
                6
            ));
            dummyLibrary.Add(new Movie(
                "Parasite", 
                new string[] { 
                    "Kang-ho Song",
                    "Sun-kyun Lee",
                    "Yeo-jeong Jo" 
                }, 
                "Bong Joon Ho", 
                132, 
                Genre.Thriller, 
                Classification.MA, 
                new DateTime(2019, 5, 30), 
                4
            ));
            dummyLibrary.Add(new Movie(
                "Marriage Story", 
                new string[] { 
                    "Adam Driver",
                    "Scarlett Johansson",
                    "Julia Greer"
                }, 
                "Noah Baumbach", 
                137, 
                Genre.Drama, 
                Classification.M, 
                new DateTime(2019, 12, 6), 
                4
            ));
            dummyLibrary.Add(new Movie(
                "Little Women", 
                new string[] { 
                    "Saoirse Ronan",
                    "Emma Watson",
                    "Florence Pugh"
                }, 
                "Greta Gerwig", 
                135, 
                Genre.Drama, 
                Classification.G, 
                new DateTime(2020, 1, 1), 
                2
            ));
            dummyLibrary.Add(new Movie(
                "Booksmart", 
                new string[] {
                    "Kaitlyn Dever",
                    "Beanie Feldstein",
                    "Jessica Williams"
                }, 
                "Olivia Wilde", 
                102, 
                Genre.Comedy, 
                Classification.MA, 
                new DateTime(2019, 6, 27), 
                8
            ));
            dummyLibrary.Add(new Movie(
                "The Farewell", 
                new string[] {
                    "Shuzhen Zhao",
                    "Awkwafina",
                    "X Mayo"
                }, 
                "Lulu Wang", 
                100, 
                Genre.Drama, 
                Classification.PG, 
                new DateTime(2019, 9, 5), 
                10
            ));
            dummyLibrary.Add(new Movie(
                "Knives Out", 
                new string[] {
                    "Daniel Craig",
                    "Chris Evans",
                    "Ana de Armas"
                }, 
                "Rian Johnson", 
                131, 
                Genre.Comedy, 
                Classification.M, 
                new DateTime(2019, 11, 28), 
                15
            ));
            dummyLibrary.Add(new Movie(
                "Joker", 
                new string[] {
                    "Joaquin Phoenix",
                    "Robert De Niro",
                    "Zazie Beetz"
                }, 
                "Todd Phillips", 
                122, 
                Genre.Thriller, 
                Classification.MA, 
                new DateTime(2019, 10, 3), 
                7
            ));
            dummyLibrary.Add(new Movie(
                "Toy Story 4", 
                new string[] {
                    "Tom Hanks",
                    "Tim Allen",
                    "Annie Potts"
                }, 
                "Josh Cooley", 
                100, 
                Genre.Family, 
                Classification.G, 
                new DateTime(2019, 6, 20), 
                25
            ));
            dummyLibrary.Add(new Movie(
                "1917", 
                new string[] {
                    "Dean-Charles Chapman",
                    "George MacKay",
                    "Daniel Mays"
                }, 
                "Sam Mendes", 
                119, 
                Genre.Drama, 
                Classification.MA, 
                new DateTime(2020, 1, 16), 
                8
            ));
            dummyLibrary.Add(new Movie(
                "Midsommar", 
                new string[] {
                    "Florence Pugh",
                    "Jack Reynor",
                    "Vilhelm Blomgren"
                }, 
                "Ari Aster", 
                148, 
                Genre.Thriller, 
                Classification.MA, 
                new DateTime(2019, 8, 8), 
                3
            ));
            return dummyLibrary;
        }
        static MemberCollection DummyMembers() {
            MemberCollection dummyMembers = new MemberCollection();
            dummyMembers.Add(new Member(
                "John", 
                "Doe", 
                "2 Kensington Terrace, 4066", 
                "0450732987", 
                "pass1", 
                new MovieCollection()
            ));

            dummyMembers.Add(new Member(
                "John", 
                "Smith", 
                "2 Kensington Street, 4067", 
                "0418781464", 
                "pass2", 
                new MovieCollection()
            ));
            dummyMembers.Add(new Member(
                "Jane", 
                "Doe", 
                "2 Kensington Place, 4068", 
                "0437723235", 
                "pass3", 
                new MovieCollection()
            ));
            dummyMembers.Add(new Member(
                "Jane", 
                "Smith", 
                "2 Kensington Grove, 4069", 
                "0456789101", 
                "pass4", 
                new MovieCollection()
            ));
            return dummyMembers;
        }
    }
}