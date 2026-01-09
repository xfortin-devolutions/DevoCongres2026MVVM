using Avalonia.Collections;
using Avalonia.Demos.Demo1_MasterDetail;
using Avalonia.Demos.Demo2_MultipleViews;
using Avalonia.Demos.Demo3_DynamicForm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private DemoItemViewModel? selectedDemo;

    public AvaloniaList<DemoItemViewModel> Demos { get; } =
    [
        new MasterDetailViewModel(),
        new MultipleViewsViewModel(),
        new DynamicFormViewModel()
    ];
}
