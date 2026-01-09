using Avalonia.Demos.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo1_MasterDetail.ProductTypes;

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

    public abstract string ProductType { get; }
}
