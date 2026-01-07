using SQLite;

namespace MerhabaDunya.Models;

public class Book
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int CategoryId { get; set; } // Kategori ile ilişki
}