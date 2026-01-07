using MerhabaDunya.Models;
using MerhabaDunya.Services;

namespace MerhabaDunya;

public partial class MainPage : ContentPage
{
    // Veritabanı servisimizi tanımlıyoruz
    private readonly DatabaseService _databaseService;

    public MainPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
        LoadBooks();
    }

    private async void LoadBooks()
    {
        // Koleksiyonu veritabanından gelen verilerle doldur
        var books = await _databaseService.GetBooksAsync();
        BooksList.ItemsSource = books;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Boş giriş kontrolü
        if (string.IsNullOrWhiteSpace(BookTitleEntry.Text)) return;

        var newBook = new Book 
        { 
            Title = BookTitleEntry.Text, 
            Author = AuthorEntry.Text 
        };

        // Veritabanına kaydet
        await _databaseService.AddBookAsync(newBook);
        
        // Giriş alanlarını temizle ve listeyi yenile
        BookTitleEntry.Text = string.Empty;
        AuthorEntry.Text = string.Empty;
        LoadBooks();
    }
}