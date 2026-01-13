using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo3_DynamicForm.Items;

public partial class BooleanItemViewModel : FormItemViewModel
{
    [ObservableProperty]
    private bool value;
}
