public class Book {
    // attributes
    public string Title { get; set; }
    public int NumPages { get; set; }
    // creates space and then puts in an empty list of <Author>
    public List<Author> Authors { get; set; } = new List<Author>();


    // operations

    // function to estimate the amount of time it takes to read a book (1 page = 3mins)
    public int TimeToRead() {
        return 3 * this.NumPages;
    }
}