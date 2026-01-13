using WinForms.Demos.Demo1_MasterDetail.ProductTypes;

namespace WinForms.Demos.Demo1_MasterDetail.DetailPanels;

public class BookDetailPanel : DetailPanel
{
    private readonly Label lblNameValue;
    private readonly Label lblPriceValue;
    private readonly Label lblDescriptionValue;
    private readonly Label lblAuthorValue;
    private readonly Label lblIsbnValue;
    private readonly Label lblPageCountValue;
    private readonly Label lblGenreValue;

    public override bool AutoScroll => true;

    public BookDetailPanel()
    {
        Padding = new Padding(20);
        
        int yPos = 0;

        CreateLabel("Book Details", ref yPos, fontStyle: FontStyle.Bold, isTitle: true);
        yPos += 20;

        CreateLabel("Name:", ref yPos, fontStyle: FontStyle.Bold);
        lblNameValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Price:", ref yPos, fontStyle: FontStyle.Bold);
        lblPriceValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Description:", ref yPos, fontStyle: FontStyle.Bold);
        lblDescriptionValue = CreateLabel("", ref yPos);
        yPos += 20;

        Panel separator = new()
        {
            Height = 1,
            Width = 900,
            BackColor = Color.LightGray,
            Location = new Point(0, yPos)
        };
        Controls.Add(separator);
        yPos += 20;

        CreateLabel("Author:", ref yPos, fontStyle: FontStyle.Bold);
        lblAuthorValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("ISBN:", ref yPos, fontStyle: FontStyle.Bold);
        lblIsbnValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Page Count:", ref yPos, fontStyle: FontStyle.Bold);
        lblPageCountValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Genre:", ref yPos, fontStyle: FontStyle.Bold);
        lblGenreValue = CreateLabel("", ref yPos);
    }

    public void LoadBook(Book book)
    {
        lblNameValue.Text = book.Name;
        lblPriceValue.Text = $"${book.Price:F2}";
        lblDescriptionValue.Text = book.Description;
        lblAuthorValue.Text = book.Author;
        lblIsbnValue.Text = book.Isbn;
        lblPageCountValue.Text = book.PageCount.ToString();
        lblGenreValue.Text = book.Genre;
    }
}
