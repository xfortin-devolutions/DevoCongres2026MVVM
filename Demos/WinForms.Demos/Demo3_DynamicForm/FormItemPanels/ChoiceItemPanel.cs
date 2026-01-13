namespace WinForms.Demos.Demo3_DynamicForm.FormItemPanels;

public class ChoiceItemPanel : Panel
{
    private readonly Label label;
    private readonly ComboBox comboBox;

    public ChoiceItemPanel(FormItems.ChoiceItem item)
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

        comboBox = new ComboBox
        {
            Location = new Point(120, 0),
            Width = 250,
            Font = new Font("Segoe UI", 10F),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        comboBox.Items.AddRange(item.Options);
        comboBox.SelectedItem = item.SelectedValue;
        comboBox.SelectedIndexChanged += (_, _) => item.SelectedValue = comboBox.SelectedItem?.ToString() ?? string.Empty;
        Controls.Add(comboBox);
    }
}
