using SQLite;
using MerhabaDunya.Models;

namespace MerhabaDunya.Services;

public class DatabaseService
{
    SQLiteAsyncConnection _database;

    async Task Init()
    {
        if (_database is not null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Library.db3");
        _database = new SQLiteAsyncConnection(dbPath);

        // Tabloları oluşturuyoruz
        await _database.CreateTableAsync<Book>();
        await _database.CreateTableAsync<Category>();
        await _database.CreateTableAsync<User>();
        await _database.CreateTableAsync<Loan>();
    }

    // Basit bir kitap ekleme metodu
    public async Task AddBook(Book book)
    {
        await Init();
        await _database.InsertAsync(book);
    }
}