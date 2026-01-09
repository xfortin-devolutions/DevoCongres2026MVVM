using Avalonia.Demos.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo1_MasterDetail.ProductTypes;

/// <summary>
/// Base class for all product types in the Master-Detail demo.
/// Contains common properties shared by all products.
/// </summary>
public abstract partial class ProductViewModel : ViewModelBase
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private decimal price;

    [ObservableProperty]
    private string description = string.Empty;

    /// <summary>
    /// Returns the type name of the product (e.g., "Book", "Electronics", "Clothing").
    /// Used for display purposes in the UI.
    /// </summary>
    public abstract string ProductType { get; }
}
