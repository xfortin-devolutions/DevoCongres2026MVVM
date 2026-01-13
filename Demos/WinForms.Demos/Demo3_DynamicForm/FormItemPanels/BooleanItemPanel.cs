namespace WinForms.Demos.Demo3_DynamicForm.FormItemPanels;

public class BooleanItemPanel : Panel
{
    private readonly CheckBox checkBox;

    public BooleanItemPanel(FormItems.BooleanItem item)
    {
        Width = 900;
        Height = 25;
        Margin = new Padding(0, 0, 0, 5);

        checkBox = new CheckBox
        {
            Text = item.Label,
            Checked = item.Value,
            Location = new Point(120, 0),
            AutoSize = true
        };
        checkBox.CheckedChanged += (_, _) => item.Value = checkBox.Checked;
        Controls.Add(checkBox);
    }
}
