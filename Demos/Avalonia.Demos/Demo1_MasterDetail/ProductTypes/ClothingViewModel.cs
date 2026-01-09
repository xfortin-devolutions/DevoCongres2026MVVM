using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo1_MasterDetail.ProductTypes;

/// <summary>
/// ViewModel for a Clothing product.
/// Demonstrates specific properties unique to clothing items.
/// </summary>
public partial class ClothingViewModel : ProductViewModel
{
    [ObservableProperty]
    private string size = string.Empty;

    [ObservableProperty]
    private string color = string.Empty;

    [ObservableProperty]
    private string material = string.Empty;

    [ObservableProperty]
    private string careInstructions = string.Empty;

    public override string ProductType => "Clothing";
}
