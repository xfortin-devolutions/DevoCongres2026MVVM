using Avalonia.Demos.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo3_DynamicForm.Items;

public abstract partial class FormItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private string label = string.Empty;
}
