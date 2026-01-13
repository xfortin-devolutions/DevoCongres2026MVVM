namespace WinForms.Demos.Demo1_MasterDetail.ProductTypes;

public class Book : Product
{
    public string Author { get; init; } = string.Empty;
    public string Isbn { get; init; } = string.Empty;
    public int PageCount { get; init; }
    public string Genre { get; init; } = string.Empty;

    public override string ProductType => "Book";
}
