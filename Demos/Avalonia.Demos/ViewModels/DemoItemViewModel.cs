namespace Avalonia.Demos.ViewModels;

public abstract class DemoItemViewModel(string title) : ViewModelBase
{
    public string Title { get; } = title;
}
