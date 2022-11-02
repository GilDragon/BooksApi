var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// refactor to have a group of books and people as classes
List<Book> myBooks = new List<Book>();
List<Person> people = new List<Person>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Books", () => myBooks);
app.MapGet("/Books/Add", (string title, int numPages, string authorFirstName, string authorSurname) => AddBook(title, numPages, authorFirstName, authorSurname));
app.MapGet("/Books/ReadTime", (string title) => TimeToRead(title));
app.MapGet("/People", () => people);
app.MapGet("/People/Add", (string name, int phone) => AddPerson(name, phone));
app.MapGet("/Borrow/", (string name, string title) => BorrowBook(name, title));


app.Run();

void AddPerson(string name, int phoneNumber) {
    var newPerson = new Person();
    newPerson.Name = name;
    newPerson.PhoneNumber = phoneNumber;

    people.Add(newPerson);
}

void BorrowBook(string person, string title) {
    // check that person exists
    Person borrower = null;
    foreach (var p in people) {
        if (p.Name == person) {
            borrower = p;
        }
    }

    // check that book exists
    Book book = null;
    foreach (var b in myBooks) {
        if (b.Title == title) {
            book = b;
        }
    }

    if (book != null && borrower != null) {
        borrower.Books.Add(book);

        myBooks.Remove(book);
    }
}

void AddBook(string title, int numPages, string authorFirstName, string authorSurname) {
    // "new Book()" creates a new object of type Book from the Book class
    // this is called instantiate
    Book newBook = new Book();
    newBook.Title = title;
    newBook.NumPages = numPages;

    Author newAuthor = new Author();
    newAuthor.FirstName = authorFirstName;
    newAuthor.Surname = authorSurname;

    newBook.Authors.Add(newAuthor);

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