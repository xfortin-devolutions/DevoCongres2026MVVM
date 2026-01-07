using Avalonia.Collections;
using Avalonia.Demos.Demo1;
using Avalonia.Demos.Demo2;
using Avalonia.Demos.Demo3;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private DemoItemViewModel? selectedDemo;

    public AvaloniaList<DemoItemViewModel> Demos { get; } = new()
    {
        new MasterDetailViewModel(),
        new MultipleViewsViewModel(),
        new DynamicFormViewModel()
    };
}
