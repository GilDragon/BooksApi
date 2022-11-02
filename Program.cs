var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Book> myBooks = new List<Book>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Books", () => myBooks);
app.MapGet("/Books/Add", (string title, int numPages) => AddBook(title, numPages));
app.MapGet("/Books/ReadTime", (string title) => TimeToRead(title));


app.Run();


void AddBook(string title, int numPages) {
    // "new Book()" creates a new object of type Book from the Book class
    // this is called instantiate
    Book newBook = new Book();
    newBook.Title = title;
    newBook.NumPages = numPages;

    myBooks.Add(newBook);
    
}

string TimeToRead(string title)
{
    Book targetBook = null;

    foreach(var tempBook in myBooks) {
        if (tempBook.Title == title) {
            targetBook = tempBook;
        }
    }

    if (targetBook == null) {
        return "Book not found";
    }

    if (targetBook != null) {
        if (targetBook.Title == "Lord of the Rings") {
            return "Forever";
        }
        return targetBook.TimeToRead().ToString();
    }

    return "There was an error";

}