namespace WinForms.Demos.Demo3_DynamicForm.FormItemPanels;

public class NumberItemPanel : Panel
{
    private readonly Label label;
    private readonly NumericUpDown numericUpDown;

    public NumberItemPanel(FormItems.NumberItem item)
    {
        Width = 900;
        Height = 25;
        Margin = new Padding(0, 0, 0, 5);

        label = new Label
        {
            Text = item.Label,
            Location = new Point(0, 2),
            Width = 120
        };
        Controls.Add(label);

        numericUpDown = new NumericUpDown
        {
            Minimum = item.Minimum,
            Maximum = item.Maximum,
            Value = item.Value,
            Increment = item.Increment,
            Location = new Point(120, 0),
            Width = 150,
            Font = new Font("Segoe UI", 10F)
        };
        numericUpDown.ValueChanged += (_, _) => item.Value = numericUpDown.Value;
        Controls.Add(numericUpDown);
    }
}
