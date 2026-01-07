namespace Avalonia.Demos.ViewModels;

public abstract class DemoItemViewModel : ViewModelBase
{
    public string Title { get; }

    protected DemoItemViewModel(string title)
    {
        Title = title;
    }
}
