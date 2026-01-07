using SQLite;

namespace MerhabaDunya.Models;

public class Loan
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
}