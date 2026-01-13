namespace WinForms.Demos.Demo3_DynamicForm.FormItems;

public class NumberItem : FormItem
{
    public decimal Value { get; set; }
    public decimal Minimum { get; init; }
    public decimal Maximum { get; init; } = 100;
    public decimal Increment { get; init; } = 1;
}
