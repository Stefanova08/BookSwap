# BookSwap

SoftUni course project - ASP.NET Fundamentals September 2026

BookSwap is a web platform for buying and selling used books. Users can list a book for sale, browse all available offers, filter them by category, and see each book’s price, condition and city at a glance.

Why this idea?

Today, most used books in Bulgaria are sold through Facebook groups. While popular, they are not built for this purpose: posts quickly get buried in the feed, there is no way to filter by category or location, and buyers constantly have to comment “Is this still available?” because sellers rarely update their posts. BookSwap solves these problems by offering a dedicated, structured space where every offer contains the key information upfront and can be easily searched. The goal is a simple, user-friendly experience that collects only the minimum personal data needed for the exchange, while ensuring that only real people take part.

## Technologies

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core 8
- SQL Server LocalDB
- Bootstrap 5

## Features

- Add, view, edit and delete books (CRUD)
- List of all books and the latest books on the home page
- Categories page with the number of books in each category
- Server-side and client-side validation of the book form

## Database

- **Book** – title, author, price, condition, description, image URL, date added
- **Category** – one category has many books
- **City** – one city has many books

Categories and cities are added automatically with the first migration.

## How to run

1. Clone the repository:
   ```
   git clone https://github.com/Stefanova08/BookSwap.git
   ```
2. Open `BookSwap.sln` in Visual Studio 2022.
3. Open **Tools → NuGet Package Manager → Package Manager Console** and run:
   ```
   Update-Database
   ```
4. Start the project with **F5**.

## Configuration

No environment variables or passwords are needed. The connection string is in `appsettings.json` and uses the default LocalDB:

```
Server=(localdb)\MSSQLLocalDB;Database=BookSwapDb;Trusted_Connection=True;MultipleActiveResultSets=true
```
