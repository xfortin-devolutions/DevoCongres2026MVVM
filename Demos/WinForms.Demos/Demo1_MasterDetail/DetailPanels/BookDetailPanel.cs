using WinForms.Demos.Demo1.ProductTypes;

namespace WinForms.Demos.Demo1.DetailPanels;

/// <summary>
/// Panel that displays detailed information for a Book product.
/// Manually creates and positions labels for each property.
/// </summary>
public class BookDetailPanel : Panel
{
    private readonly Label lblTitle;
    private readonly Label lblName;
    private readonly Label lblPrice;
    private readonly Label lblDescription;
    private readonly Label lblAuthor;
    private readonly Label lblIsbn;
    private readonly Label lblPageCount;
    private readonly Label lblGenre;

    private readonly Label lblNameValue;
    private readonly Label lblPriceValue;
    private readonly Label lblDescriptionValue;
    private readonly Label lblAuthorValue;
    private readonly Label lblIsbnValue;
    private readonly Label lblPageCountValue;
    private readonly Label lblGenreValue;

    public BookDetailPanel()
    {
        AutoScroll = true;
        Padding = new Padding(20);

        int yPos = 0;

        // Title
        lblTitle = CreateLabel("Book Details", new Font("Segoe UI", 16F, FontStyle.Bold), ref yPos);
        yPos += 20;

        // Name
        lblName = CreateLabel("Name:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblNameValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Price
        lblPrice = CreateLabel("Price:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblPriceValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Description
        lblDescription = CreateLabel("Description:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblDescriptionValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos, maxWidth: 350);
        yPos += 20;

        // Separator line
        var separator = new Panel
        {
            Height = 1,
            Width = 400,
            BackColor = Color.LightGray,
            Location = new Point(0, yPos)
        };
        Controls.Add(separator);
        yPos += 20;

        // Author
        lblAuthor = CreateLabel("Author:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblAuthorValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // ISBN
        lblIsbn = CreateLabel("ISBN:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblIsbnValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Page Count
        lblPageCount = CreateLabel("Page Count:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblPageCountValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Genre
        lblGenre = CreateLabel("Genre:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblGenreValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
    }

    private Label CreateLabel(string text, Font font, ref int yPos, int maxWidth = 400)
    {
        var label = new Label
        {
            Text = text,
            Font = font,
            Location = new Point(0, yPos),
            AutoSize = true,
            MaximumSize = new Size(maxWidth, 0)
        };
        Controls.Add(label);
        yPos += label.PreferredHeight;
        return label;
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
