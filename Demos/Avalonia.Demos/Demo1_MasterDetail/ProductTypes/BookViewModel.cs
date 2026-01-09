using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo1_MasterDetail.ProductTypes;

/// <summary>
/// ViewModel for a Book product.
/// Demonstrates specific properties unique to books.
/// </summary>
public partial class BookViewModel : ProductViewModel
{
    [ObservableProperty]
    private string author = string.Empty;

    [ObservableProperty]
    private string isbn = string.Empty;

    [ObservableProperty]
    private int pageCount;

    [ObservableProperty]
    private string genre = string.Empty;

    public override string ProductType => "Book";
}
