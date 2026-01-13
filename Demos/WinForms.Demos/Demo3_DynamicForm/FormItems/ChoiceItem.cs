namespace WinForms.Demos.Demo3_DynamicForm.FormItems;

public class ChoiceItem : FormItem
{
    public string SelectedValue { get; set; } = string.Empty;
    public List<string> Options { get; init; } = [];
}
