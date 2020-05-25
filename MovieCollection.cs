using System;
using System.Globalization;
namespace a1 {
    public class MovieCollection {
        private MovieNode root;
        public string sort = "title";
        public MovieCollection() {
            root = null;
        }
        public MovieCollection(string s) {
            root = null;
            if(sort == "title" || sort == "top") sort = s;
            else sort = "title";
        }
        public bool IsEmpty() {
            return root != null ? false : true;
        }
        public Movie Find(String title) {
            return Find(title, root);
        }
        public Movie Find(String title, MovieNode r) {
            if(r == null) return null;
            if(title.CompareTo(r.Movie.Title) == 0) return r.Movie;
            if(title.CompareTo(r.Movie.Title) < 0) return Find(title, r.Left);
            return Find(title, r.Right);
        }
        public void Add(Movie movie) {
            if(root != null) {
                Add(movie, root);
            } else {
                root = new MovieNode(movie);
            }
        }
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
        public int Size() {
            return Size(root);
        }
        public int Size(MovieNode r) {
            return r == null ? 0 : Size(r.Left) + 1 + Size(r.Right);
        }
        public void Delete(String title) {
            MovieNode pointer = root;
            MovieNode parent = null;
            while((pointer != null) && (title.CompareTo(pointer.Movie.Title) != 0)) {
                parent = pointer;
                if(title.CompareTo(pointer.Movie.Title) < 0) {
                    pointer = pointer.Left;
                } else {
                    pointer = pointer.Right;
                }
            }
            if(pointer != null) {
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
        public int Subcollection(MovieNode root, MovieCollection sub, int start, int end, int index, string sort) {
            if(root != null && sort == "title") {
                index = Subcollection(root.Left, sub, start, end, index, sort);
                if(index >= start) {
                    if(index >= end) return index;
                    sub.Add(root.Movie);
                }
                index++;
                index = Subcollection(root.Right, sub, start, end, index, sort);
                return index;
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
        public void Display(int page = 1) {
            if(sort == "title") Display(root);
            if(sort == "top") TopTen(page);
        }
        public static string Truncate(string s, int size = 29) {
            if(string.IsNullOrEmpty(s)) return s;
            return s.Length <= size ? s : s.Substring(0, size);
        }
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
        public void TopTen(int page) {
            int counter = 1;
            TopTen(root, ref counter, page);
        }
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
        public MovieCollection TreeSort() {
            MovieCollection treeSort = new MovieCollection();
            TreeSort(root, treeSort);
            return treeSort;
        }
        public void TreeSort(MovieNode root, MovieCollection treeSort) {
            if(root != null) {
                TreeSort(root.Left, treeSort);
                TreeSort(root.Right, treeSort);
            }
        }
    }
}
