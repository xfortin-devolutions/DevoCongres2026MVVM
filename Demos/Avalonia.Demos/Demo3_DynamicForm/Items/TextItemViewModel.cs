using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo3_DynamicForm.Items;

public partial class TextItemViewModel : FormItemViewModel
{
    [ObservableProperty]
    private string value = string.Empty;
}
