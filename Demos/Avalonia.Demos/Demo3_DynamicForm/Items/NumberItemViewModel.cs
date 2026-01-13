using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo3_DynamicForm.Items;

public partial class NumberItemViewModel : FormItemViewModel
{
    [ObservableProperty]
    private decimal value;

    [ObservableProperty]
    private decimal minimum;

    [ObservableProperty]
    private decimal maximum = 100;

    [ObservableProperty]
    private decimal increment = 1;
}
