using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo3_DynamicForm.Items;

public partial class ChoiceItemViewModel : FormItemViewModel
{
    [ObservableProperty]
    private string selectedValue = string.Empty;

    public AvaloniaList<string> Options { get; } = new();
}
