using Avalonia.Collections;
using Avalonia.Demos.Demo3_DynamicForm.Items;
using Avalonia.Demos.ViewModels;

namespace Avalonia.Demos.Demo3_DynamicForm;

public class DynamicFormViewModel : DemoItemViewModel
{
    public AvaloniaList<FormItemViewModel> FormItems { get; } = [];
    
    public DynamicFormViewModel() : base("Demo 3: Dynamic Form Composition")
    {
        FormItems.AddRange(
        [
            new TextItemViewModel
            {
                Label = "Full Name",
                Value = "John Doe"
            },
            new TextItemViewModel
            {
                Label = "Email Address",
                Value = "john.doe@example.com"
            },
            new NumberItemViewModel
            {
                Label = "Age",
                Value = 30,
                Minimum = 18,
                Maximum = 120,
                Increment = 1
            },
            new ChoiceItemViewModel
            {
                Label = "Country",
                Options = { "Canada", "United States", "United Kingdom", "France", "Germany", "Japan" },
                SelectedValue = "Canada"
            },
            new BooleanItemViewModel
            {
                Label = "Subscribe to Newsletter",
                Value = true
            },
            new NumberItemViewModel
            {
                Label = "Salary Expectation",
                Value = 75000,
                Minimum = 0,
                Maximum = 500000,
                Increment = 5000
            },
            new ChoiceItemViewModel
            {
                Label = "Experience Level",
                Options = { "Junior", "Intermediate", "Senior", "Lead", "Principal" },
                SelectedValue = "Intermediate"
            },
            new BooleanItemViewModel
            {
                Label = "Remote Work Available",
                Value = false
            },
            new TextItemViewModel
            {
                Label = "LinkedIn Profile",
                Value = "https://linkedin.com/in/johndoe"
            },
            new ChoiceItemViewModel
            {
                Label = "Preferred Language",
                Options = { "English", "French", "Spanish", "German", "Mandarin" },
                SelectedValue = "English"
            }
        ]);
    }
}
