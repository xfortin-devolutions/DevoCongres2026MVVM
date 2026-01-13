namespace WinForms.Demos.Demo3_DynamicForm.FormItemPanels;

public class TextItemPanel : Panel
{
    private readonly Label label;
    private readonly TextBox textBox;

    public TextItemPanel(FormItems.TextItem item)
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

        textBox = new TextBox
        {
            Text = item.Value,
            Location = new Point(120, 0),
            Width = 400,
            Font = new Font("Segoe UI", 10F)
        };
        textBox.TextChanged += (_, _) => item.Value = textBox.Text;
        Controls.Add(textBox);
    }
}
