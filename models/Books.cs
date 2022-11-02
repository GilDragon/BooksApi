public class Book {
    // attributes
    public string Title { get; set; }
    public int NumPages { get; set; }
    public List<Author> Authors { get; set; }


    // operations

    // function to estimate the amount of time it takes to read a book (1 page = 3mins)
    public int TimeToRead() {
        return 3 * this.NumPages;
    }
}