public class Person {
    public string Name { get; set; }
    public int PhoneNumber { get; set; }
    public string Address { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();

    void BorrowBook(Book borrowedBook) {
        this.Books.Add(borrowedBook);
    }

    void ReturnBook(Book returnedBook) {
        // look for returned book to see if it is in Books
        // you may want to use a foreach loop

        // if found, remove the book from books
    }

}