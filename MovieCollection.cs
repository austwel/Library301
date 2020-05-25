using System;
using System.Globalization;
namespace a1 {
    //Collection of Movie objects in a Binary Search Tree data structure
    public class MovieCollection {
        private MovieNode root; //Root node of the Binary Search Tree
        public string sort = "title"; //What this collection object is sorted by
        public MovieCollection() {
            root = null;
        }
        //Constructor with optional string to specify sorting arrangements
        //Input: string sorting method
        //Output: this.sort = sorting method
        public MovieCollection(string s) {
            root = null;
            if(sort == "title" || sort == "top") sort = s;
            else sort = "title";
        }
        //Checks if the tree is empty
        //Input: None
        //Output: bool root node does not exist
        public bool IsEmpty() {
            return root != null ? false : true;
        }
        //Finds Movie in the collection by its unique title
        //Input: string title
        //Output: Movie movie with given title value
        public Movie Find(string title) {
            return Find(title, root);
        }
        //Recursive function to find movie by traversing the Binary Search Tree efficiently
        //Input: string title, MovieNode node
        //Output: Movie movie if node's movie value is correct, otherwise traverse deeper towards the correct node
        public Movie Find(string title, MovieNode r) {
            if(r == null) return null;
            if(title.CompareTo(r.Movie.Title) == 0) return r.Movie;
            if(title.CompareTo(r.Movie.Title) < 0) return Find(title, r.Left);
            return Find(title, r.Right);
        }
        //Add a movie to this collection
        //Input: Movie movie
        //Output: Movie movie added to the Binary Search Tree
        public void Add(Movie movie) {
            if(root != null) {
                Add(movie, root);
            } else {
                root = new MovieNode(movie);
            }
        }
        //Recursive function for adding a movie into the Binary Search Tree in the correct place
        //Input: Movie movie, MovieNode node
        //Output: Movie movie added to the Binary Search Tree if it belongs as one of the
        //        current node's children, otherwise traverse deeper towards where it belongs
        public void Add(Movie movie, MovieNode node) {
            int compare = sort == "title" ? 
                movie.Title.CompareTo(node.Movie.Title) :
                movie.Borrowed.CompareTo(node.Movie.Borrowed);
            if(compare < 0) {
                if(node.Left != null) Add(movie, node.Left);
                else node.Left = new MovieNode(movie);
            } else {
                if(node.Right != null) Add(movie, node.Right);
                else node.Right = new MovieNode(movie);
            }
        }
        //Gets the size of the Binary Search Tree
        //Input: None
        //Output: int amount of nodes in the tree
        public int Size() {
            return Size(root);
        }
        //Recursive function for the amount of nodes in the tree
        //Input: MovieNode node
        //Output: int amount of nodes below and including current node
        public int Size(MovieNode r) {
            return r == null ? 0 : Size(r.Left) + 1 + Size(r.Right);
        }
        //Deletes a MovieNode from the tree given its title
        //Input: string title
        //Output: this object's Binary Search Tree with the given Movie's node removed
        public void Delete(string title) {
            MovieNode pointer = root;
            MovieNode parent = null;
            while((pointer != null) && (title.CompareTo(pointer.Movie.Title) != 0)) { //Traverse until found the node to delete
                parent = pointer;
                if(title.CompareTo(pointer.Movie.Title) < 0) {
                    pointer = pointer.Left;
                } else {
                    pointer = pointer.Right;
                }
            }
            if(pointer != null) { //Reassign children of removed node into the tree
                if((pointer.Left != null) && (pointer.Right != null)) {
                    if(pointer.Left.Right == null) {
                        pointer.Movie = pointer.Left.Movie;
                        pointer.Left = pointer.Left.Left;
                    } else {
                        MovieNode p = pointer.Left;
                        MovieNode pp = pointer;
                        while(p.Right != null) {
                            pp = p;
                            p = p.Right;
                        }
                        pointer.Movie = p.Movie;
                        pp.Right = p.Left;
                    }
                } else {
                    MovieNode c;
                    if(pointer.Left != null) {
                        c = pointer.Left;
                    } else {
                        c = pointer.Right;
                    }
                    if(pointer == root) {
                        root = c;
                    } else if(pointer == parent.Left) {
                        parent.Left = c;
                    } else {
                        parent.Right = c;
                    }
                }
            }
        }
        //Generates another MovieCollection which contains a subset of the current collection by in order traversal
        //Input: int start of new collection, int end of new collection, string new collection's sorting method (by title or borrowed)
        //Output: new MovieCollection of size (end-start) sorted by the given sorting technique
        public MovieCollection Subcollection(int start, int end, string sortBy = "title") {
            int size = this.Size();
            if(start > end) (end, start) = (start, end);
            if(start < 0) start = 0;
            if(end > size) end = size;
            MovieCollection sub = new MovieCollection(sortBy);
            int index = 0;
            Subcollection(root, sub, start, end, index, sub.sort);
            return sub;
        }
        //Recursive function for creating nodes inside the new subcollection
        //Input: MovieNode current node of old tree, MovieCollection new subcollection, int start, int end, int index of node to be visited, string sorting method
        //Output: int index of how many items have already been traversed, current node from old tree added to subcollection if index is between start and end
        public int Subcollection(MovieNode root, MovieCollection sub, int start, int end, int index, string sort) {
            if(root != null && sort == "title") {
                index = Subcollection(root.Left, sub, start, end, index, sort);
                if(index >= start) {
                    if(index >= end) return index;
                    sub.Add(root.Movie);
                }
                index++;
                index = Subcollection(root.Right, sub, start, end, index, sort);
            } else if(root != null && sort == "top") {
                index = Subcollection(root.Right, sub, start, end, index, sort);
                if(index >= start) {
                    if(index >= end) return index;
                    sub.Add(root.Movie);
                }
                index++;
                index = Subcollection(root.Left, sub, start, end, index, sort);
            }
            return index;
        }
        //Display switch between displaying topten and all movies
        //Input: page number (only for TopTen)
        //Output: Writes formatted movie data into console
        public void Display(int page = 1) {
            if(sort == "title") Display(root);
            if(sort == "top") TopTen(page);
        }
        //Truncates string to fit into given size to not overflow on screen
        //Input: string s, int size (default 29)
        //Output: string s truncated to at most *size* characters long
        public static string Truncate(string s, int size = 29) {
            if(string.IsNullOrEmpty(s)) return s;
            return s.Length <= size ? s : s.Substring(0, size);
        }
        //Displays movie data for a given node
        //Input: MovieNode node
        //Output: Writes this node's movie data into the console
        public void Display(MovieNode root) {
            if(root != null) {
                Display(root.Left);
                Console.WriteLine("================================================");
                Console.WriteLine("   {0, -15} {1, 29}", "Title:", root.Movie.Title);
                Console.WriteLine("   {0, -15} {1, 29}", "Stars:", Truncate(string.Join(", ", root.Movie.Starring)));
                Console.WriteLine("   {0, -15} {1, 29}", "Director:", root.Movie.Director);
                Console.WriteLine("   {0, -15} {1, 29}", "Duration:", root.Movie.Duration.ToString() + " minutes");
                Console.WriteLine("   {0, -15} {1, 29}", "Genre:", root.Movie.Genre.ToString());
                Console.WriteLine("   {0, -15} {1, 29}", "Classification:", root.Movie.Classification.ToString());
                Console.WriteLine("   {0, -15} {1, 29}", "Release Date:", root.Movie.ReleaseDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
                Console.WriteLine("   {0, -15} {1, 29}", "Copies:", root.Movie.Copies.ToString());
                Console.WriteLine("================================================");
                Display(root.Right);
            }
        }
        //Displays the top ten movies by times borrowed for each page (1 or 2) with 5 items per page
        //Input: int page
        //Output: Writes movie title and borrowed data into the console
        public void TopTen(int page) {
            int counter = 1;
            TopTen(root, ref counter, page);
        }
        //Recursive function to display movie data for the given subcollection
        //Input: MovieNode root of "borrowed" sorted subcollection of size 10, reference to an int counting which ranking the current node is,
        //       int page
        //Output: Writes current node's ranking, movie title and borrowed count into the console
        public void TopTen(MovieNode root, ref int counter, int page) {
            if(root != null && counter < 10) {
                TopTen(root.Right, ref counter, page);
                Console.WriteLine("   {0, -24} {1, 20}",
                    (counter+(page-1)*5).ToString() + ((counter+(page-1)*5) == 10 ? ". " : ".  ") + Truncate(root.Movie.Title, 20),
                    "Borrowed " + root.Movie.Borrowed.ToString() + " times");
                counter++;
                TopTen(root.Left, ref counter, page);
            }
        }
    }
}
