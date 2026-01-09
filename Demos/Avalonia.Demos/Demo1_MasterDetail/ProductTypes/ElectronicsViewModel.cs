using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo1_MasterDetail.ProductTypes;

/// <summary>
/// ViewModel for an Electronics product.
/// Demonstrates specific properties unique to electronics.
/// </summary>
public partial class ElectronicsViewModel : ProductViewModel
{
    [ObservableProperty]
    private string brand = string.Empty;

    [ObservableProperty]
    private int warrantyMonths;

    [ObservableProperty]
    private string powerConsumption = string.Empty;

    [ObservableProperty]
    private string modelNumber = string.Empty;

    public override string ProductType => "Electronics";
}
