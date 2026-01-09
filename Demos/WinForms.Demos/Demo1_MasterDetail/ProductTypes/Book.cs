namespace WinForms.Demos.Demo1.ProductTypes;

public class Book : Product
{
    public string Author { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int PageCount { get; set; }
    public string Genre { get; set; } = string.Empty;

    public override string ProductType => "Book";
}
